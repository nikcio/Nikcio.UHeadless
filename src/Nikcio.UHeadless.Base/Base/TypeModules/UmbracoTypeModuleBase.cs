﻿using System.Reflection;
using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Extensions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.TypeModules;

/// <summary>
/// Represents the base for creating type modules for the Umbraco types like ContentType and MediaType
/// </summary>
public abstract class UmbracoTypeModuleBase<TContentType, TNamedProperties> : ITypeModule
    where TContentType : IContentTypeComposition
    where TNamedProperties : INamedProperties
{
    /// <summary>
    /// The key used for the scoped context value for the element being queried
    /// </summary>
    public const string ElementScopedStateKey = "_element";

    /// <summary>
    /// Represents the property map
    /// </summary>
    protected readonly IPropertyMap PropertyMap;

    /// <inheritdoc/>
    public event EventHandler<EventArgs>? TypesChanged;

    /// <inheritdoc/>
    protected UmbracoTypeModuleBase(IPropertyMap propertyMap)
    {
        PropertyMap = propertyMap;
    }

    /// <summary>
    /// Call this when the types have changed
    /// </summary>
    /// <param name="eventArgs"></param>
    public void OnTypesChanged(EventArgs eventArgs)
    {
        TypesChanged?.Invoke(this, eventArgs);
    }

    /// <summary>
    /// Gets the interface type name for the interface type definition
    /// </summary>
    /// <param name="contentTypeAlias"></param>
    /// <returns></returns>
    protected static string GetInterfaceTypeName(string contentTypeAlias)
    {
        return string.Concat("I", GetObjectTypeName(contentTypeAlias));
    }

    /// <summary>
    /// Gets the object type name for the object type definition
    /// </summary>
    /// <param name="contentTypeAlias"></param>
    /// <returns></returns>
    protected static string GetObjectTypeName(string contentTypeAlias)
    {
        return contentTypeAlias.FirstCharToUpper();
    }

    /// <inheritdoc/>
    public ValueTask<IReadOnlyCollection<ITypeSystemMember>> CreateTypesAsync(IDescriptorContext context, CancellationToken cancellationToken)
    {
        var types = new List<ITypeSystemMember>();

        var objectTypes = new List<ObjectType>();

        AddEmptyPropertyType(objectTypes);

        var contentTypes = GetContentTypes().ToArray();

        foreach (var contentType in contentTypes)
        {
            var interfaceTypeDefinition = CreateInterfaceTypeDefinition(contentType);

            if (interfaceTypeDefinition.Fields.Count == 0)
            {
                continue;
            }

            types.Add(InterfaceType.CreateUnsafe(interfaceTypeDefinition));

            var objectTypeDefinition = CreateObjectTypeDefinition(contentType);

            if (objectTypeDefinition.Fields.Count == 0)
            {
                continue;
            }

            var objectType = ObjectType.CreateUnsafe(objectTypeDefinition);

            objectTypes.Add(objectType);

            types.Add(objectType);
        }

        var namedPropertiesUnion = new UnionType<TNamedProperties>(d =>
        {
            d.ResolveAbstractType((context, result) =>
            {
                var element = context.ScopedContextData[ElementScopedStateKey];

                if (element is not Element elementCasted)
                {
                    return default;
                }

                var content = elementCasted.GetContent();

                if (content == null)
                {
                    return default;
                }

                return objectTypes.Find(type => type.Name == GetObjectTypeName(content.ContentType.Alias)) ?? objectTypes[0];
            });

            foreach (var objectType in objectTypes)
            {
                d.Type(objectType);
            }
        });

        types.Add(namedPropertiesUnion);

        return new ValueTask<IReadOnlyCollection<ITypeSystemMember>>(types);
    }

    /// <summary>
    /// Adds a placeholder empty type that is used when the matching content type doesn't have a type in the schema.
    /// </summary>
    /// <param name="objectTypes"></param>
    private static void AddEmptyPropertyType(List<ObjectType> objectTypes)
    {
        var emptyNamedProperty = new ObjectTypeDefinition($"Empty{typeof(TNamedProperties).Name}", "Represents a content type that doesn't have any properties and therefore needs a placeholder");
        emptyNamedProperty.Fields.Add(new ObjectFieldDefinition("Empty_Field", "Placeholder field. Will never hold a value.", type: TypeReference.Parse("String!"), pureResolver: _ => string.Empty));
        objectTypes.Add(ObjectType.CreateUnsafe(emptyNamedProperty));
    }

    /// <summary>
    /// Gets the content types to register in the GraphQL schema
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerable<TContentType> GetContentTypes();

    private ObjectTypeDefinition CreateObjectTypeDefinition(TContentType contentType)
    {
        var typeDefinition = new ObjectTypeDefinition(GetObjectTypeName(contentType.Alias), contentType.Description);

        foreach (var property in contentType.CompositionPropertyTypes)
        {
            string propertyTypeName = PropertyMap.GetPropertyTypeName(contentType.Alias, property.Alias, property.PropertyEditorAlias);

            var propertyType = Type.GetType(propertyTypeName);

            if (propertyType == null)
            {
                continue;
            }

            typeDefinition.Fields.Add(new ObjectFieldDefinition(property.Alias, property.Description, TypeReference.Parse(propertyType.Name), pureResolver: context =>
            {
                var propertyValueFactory = context.Service<IPropertyValueFactory>();

                var element = context.ScopedContextData[ElementScopedStateKey];

                if (element is not Element elementCasted)
                {
                    return default;
                }

                var content = elementCasted.GetContent();

                if (content == null)
                {
                    return default;
                }

                var culture = elementCasted.GetCulture();

                var segment = elementCasted.GetSegment();

                var fallback = elementCasted.GetFallback();

                var property = content.GetProperty(context.Selection.ResponseName);

                if (property == null)
                {
                    return default;
                }

                var createPropertyValue = new CreatePropertyValue(content, property, culture, segment, context.Service<IPublishedValueFallback>(), fallback);
                return propertyValueFactory.GetPropertyValue(createPropertyValue);
            }));
        }

        foreach (var composite in contentType.CompositionAliases())
        {
            typeDefinition.Interfaces.Add(TypeReference.Parse(GetInterfaceTypeName(composite)));
        }

        typeDefinition.Interfaces.Add(TypeReference.Parse(GetInterfaceTypeName(typeDefinition.Name)));

        return typeDefinition;
    }

    private InterfaceTypeDefinition CreateInterfaceTypeDefinition(TContentType contentType)
    {
        var interfaceTypeDefinition = new InterfaceTypeDefinition(GetInterfaceTypeName(contentType.Alias), contentType.Description);

        foreach (var property in contentType.CompositionPropertyTypes)
        {
            string propertyTypeName = PropertyMap.GetPropertyTypeName(contentType.Alias, property.Alias, property.PropertyEditorAlias);

            var propertyType = Type.GetType(propertyTypeName);

            if (propertyType == null)
            {
                continue;
            }

            interfaceTypeDefinition.Fields.Add(new InterfaceFieldDefinition(property.Alias, property.Description, TypeReference.Parse(propertyType.Name)));
        }

        return interfaceTypeDefinition;
    }
}