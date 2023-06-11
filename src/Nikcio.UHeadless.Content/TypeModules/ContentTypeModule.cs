using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate.Data.Projections.Context;
using HotChocolate.Execution.Configuration;
using HotChocolate.Execution.Processing;
using HotChocolate.Resolvers;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using Lucene.Net.Util;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Models;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Notifications;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.Content.TypeModules;

/// <summary>
/// A module to create models to fetch properties based on content types
/// </summary>
public class ContentTypeModule : ITypeModule
{
    private readonly IContentTypeService _contentTypeService;
    private readonly IPropertyMap _propertyMap;

    /// <inheritdoc/>
    public event EventHandler<EventArgs>? TypesChanged;

    /// <inheritdoc/>
    public ContentTypeModule(IContentTypeService contentTypeService, IPropertyMap propertyMap)
    {
        _contentTypeService = contentTypeService;
        _propertyMap = propertyMap;
    }

    /// <summary>
    /// Call this when the types have changed
    /// </summary>
    /// <param name="eventArgs"></param>
    public void OnTypesChanged(EventArgs eventArgs)
    {
        TypesChanged?.Invoke(this, eventArgs);
    }

    /// <inheritdoc/>
    public async ValueTask<IReadOnlyCollection<ITypeSystemMember>> CreateTypesAsync(IDescriptorContext context, CancellationToken cancellationToken)
    {
        var types = new List<ITypeSystemMember>();

        var unionTypeDefinition = new UnionTypeDefinition(nameof(ContentProperties));
                
        var contentTypes = _contentTypeService.GetAll().ToArray();

        var basicContentTypeReferences = new List<TypeReference>();

        foreach(var type in contentTypes)
        {
            var interfaceTypeDeinition = new InterfaceTypeDefinition("I" + type.Alias[0].ToString().ToUpper() + type.Alias[1..], type.Description);

            foreach (var property in type.CompositionPropertyTypes)
            {
                string propertyTypeAssemblyQualifiedName = _propertyMap.GetPropertyTypeAssemblyQualifiedName(type.Alias, property.Alias, property.PropertyEditorAlias);

                var propertyType = Type.GetType(propertyTypeAssemblyQualifiedName);

                if (propertyType == null)
                {
                    continue;
                }

                interfaceTypeDeinition.Fields.Add(new InterfaceFieldDefinition(property.Alias, property.Description, TypeReference.Parse(propertyType.Name)));
            }

            if(interfaceTypeDeinition.Fields.Count == 0)
            {
                continue;
            }

            var interfaceTypeReference = TypeReference.Parse(interfaceTypeDeinition.Name);

            basicContentTypeReferences.Add(interfaceTypeReference);

            types.Add(InterfaceType.CreateUnsafe(interfaceTypeDeinition));
            
            var processedType = ProcessType(type);
            
            if (processedType.Fields.Count == 0)
            {
                continue;
            }

            var typeReference = TypeReference.Parse(processedType.Name);

            unionTypeDefinition.Types.Add(typeReference);

            types.Add(ObjectType.CreateUnsafe(processedType));
        }


        if (unionTypeDefinition.Types.Count != 0)
        {

            var basicContent = new ObjectType<BasicContent>(d =>
            {
                d.BindFieldsImplicitly();
                d.Extend().Definition.Interfaces.AddRange(basicContentTypeReferences);
                d.Field(t => t.ContentProperties)
                    .Resolve(ctx =>
                    {
                        var result = new ContentProperties();
                        return result;
                    })
                    .Extend()
                    .Definition.Type = TypeReference.Parse(unionTypeDefinition.Name);
            });

            types.Add(UnionType.CreateUnsafe(unionTypeDefinition));

            types.Add(basicContent);
        }

        return types;
    }

    private ObjectTypeDefinition ProcessType(IContentType contentType)
    {
        var typeDefinition = new ObjectTypeDefinition(contentType.Alias[0].ToString().ToUpper() + contentType.Alias[1..], contentType.Description);

        foreach(var property in contentType.CompositionPropertyTypes)
        {
            string propertyTypeAssemblyQualifiedName = _propertyMap.GetPropertyTypeAssemblyQualifiedName(contentType.Alias, property.Alias, property.PropertyEditorAlias);

            var propertyType = Type.GetType(propertyTypeAssemblyQualifiedName);

            if(propertyType == null)
            {
                continue;
            }

            typeDefinition.Fields.Add(new ObjectFieldDefinition(property.Alias, property.Description, TypeReference.Parse(propertyType.Name), pureResolver: context =>
            {
                var propertyValueFactory = context.Service<IPropertyValueFactory>();
                var parent = context.Parent<Element<BasicProperty>>();

                if(parent.Content == null)
                {
                    return default;
                }

                var property = parent.Content.GetProperty("");

                if (property == null)
                {
                    return default;
                }

                var createPropertyValue = new CreatePropertyValue(parent.Content, property, parent.Culture, parent.Segment, context.Service<IPublishedValueFallback>(), parent.Fallback);

                return propertyValueFactory.GetPropertyValue(createPropertyValue);
            }));
        }
        
        foreach(var composite in contentType.CompositionAliases())
        {
            typeDefinition.Interfaces.Add(TypeReference.Parse("I" + composite[0].ToString().ToUpper() + composite[1..]));
        }

        typeDefinition.Interfaces.Add(TypeReference.Parse("I" + typeDefinition.Name));

        return typeDefinition;
    }
}

/// <summary>
/// Notification on umbraco started
/// </summary>
public class UmbracoApplicationStartedHandler : INotificationAsyncHandler<UmbracoApplicationStartedNotification>, INotificationAsyncHandler<ContentTypeCacheRefresherNotification>, INotificationAsyncHandler<ContentTypeChangedNotification>
{
    private readonly ContentTypeModule _contentTypeModule;

    /// <inheritdoc/>
    public UmbracoApplicationStartedHandler(ContentTypeModule contentTypeModule)
    {
        _contentTypeModule = contentTypeModule;
    }

    /// <inheritdoc/>
    public Task HandleAsync(UmbracoApplicationStartedNotification notification, CancellationToken cancellationToken)
    {
        _contentTypeModule.OnTypesChanged(EventArgs.Empty);

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(ContentTypeChangedNotification notification, CancellationToken cancellationToken)
    {
        _contentTypeModule.OnTypesChanged(EventArgs.Empty);

        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task HandleAsync(ContentTypeCacheRefresherNotification notification, CancellationToken cancellationToken)
    {
        _contentTypeModule.OnTypesChanged(EventArgs.Empty);

        return Task.CompletedTask;
    }
}
