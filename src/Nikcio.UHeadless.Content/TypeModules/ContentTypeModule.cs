using HotChocolate.Execution.Configuration;
using HotChocolate.Types;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Descriptors.Definitions;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Extensions;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.Content.TypeModules;

/// <summary>
/// A module to create models to fetch properties based on content types
/// </summary>
public class ContentTypeModule : ITypeModule
{
    private readonly IContentTypeService _contentTypeService;
    private readonly IPropertyMap _propertyMap;

    /// <summary>
    /// The key used for the scoped context value for the element being queried
    /// </summary>
    public const string ElementScopedStateKey = "_element";

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
    public ValueTask<IReadOnlyCollection<ITypeSystemMember>> CreateTypesAsync(IDescriptorContext context, CancellationToken cancellationToken)
    {
        var types = new List<ITypeSystemMember>();

        var objectTypes = new List<ObjectType>();

        var contentTypes = _contentTypeService.GetAll().ToArray();

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

        if (contentTypes.Length == 0)
        {
            var placeholderType = new ObjectTypeDefinition(GetObjectTypeName("Placeholder"), "Create some content types in Umbraco before you use the NamedProperties. (This model will be removed when some content types are available)");

            placeholderType.Fields.Add(new ObjectFieldDefinition("PlaceholderField", type: TypeReference.Parse("String!"), pureResolver: _ => string.Empty));

            objectTypes.Add(ObjectType.CreateUnsafe(placeholderType));
        }

        var namedPropertiesUnion = new UnionType<INamedProperties>(d =>
        {
            d.ResolveAbstractType((context, result) =>
            {
                var element = context.ScopedContextData[ElementScopedStateKey];

                var elementType = element?.GetType();

                if (element == null || elementType == null || ValidateElementType(elementType))
                {
                    return default;
                }

                /*
                 * It doesn't matter that we use Element<BasicProperty> here because we just need the name of the property.
                 */

                var content = (IPublishedContent?) elementType.GetProperty(nameof(Element<BasicProperty>.Content))?.GetValue(element);

                if (content == null)
                {
                    return default;
                }

                return objectTypes.Find(type => type.Name == GetObjectTypeName(content.ContentType.Alias));
            });

            foreach (var objectType in objectTypes)
            {
                d.Type(objectType);
            }
        });

        types.Add(namedPropertiesUnion);

        return new ValueTask<IReadOnlyCollection<ITypeSystemMember>>(types);
    }

    private static bool ValidateElementType(Type elementType)
    {
        return typeof(Element<>).IsAssignableFrom(elementType);
    }

    private static string GetObjectTypeName(string contentTypeAlias)
    {
        return contentTypeAlias.FirstCharToUpper();
    }

    private static string GetInterfaceTypeName(string contentTypeAlias)
    {
        return string.Concat("I", GetObjectTypeName(contentTypeAlias));
    }

    private InterfaceTypeDefinition CreateInterfaceTypeDefinition(IContentType contentType)
    {
        var interfaceTypeDefinition = new InterfaceTypeDefinition(GetInterfaceTypeName(contentType.Alias), contentType.Description);

        foreach (var property in contentType.CompositionPropertyTypes)
        {
            string propertyTypeName = _propertyMap.GetPropertyTypeName(contentType.Alias, property.Alias, property.PropertyEditorAlias);

            var propertyType = Type.GetType(propertyTypeName);

            if (propertyType == null)
            {
                continue;
            }

            interfaceTypeDefinition.Fields.Add(new InterfaceFieldDefinition(property.Alias, property.Description, TypeReference.Parse(propertyType.Name)));
        }

        return interfaceTypeDefinition;
    }

    private ObjectTypeDefinition CreateObjectTypeDefinition(IContentType contentType)
    {
        var typeDefinition = new ObjectTypeDefinition(GetObjectTypeName(contentType.Alias), contentType.Description);

        foreach (var property in contentType.CompositionPropertyTypes)
        {
            string propertyTypeName = _propertyMap.GetPropertyTypeName(contentType.Alias, property.Alias, property.PropertyEditorAlias);

            var propertyType = Type.GetType(propertyTypeName);

            if (propertyType == null)
            {
                continue;
            }

            typeDefinition.Fields.Add(new ObjectFieldDefinition(property.Alias, property.Description, TypeReference.Parse(propertyType.Name), pureResolver: context =>
            {
                var propertyValueFactory = context.Service<IPropertyValueFactory>();

                var element = context.ScopedContextData[ElementScopedStateKey];

                var elementType = element?.GetType();

                if (element == null || elementType == null || ValidateElementType(elementType))
                {
                    return default;
                }

                /*
                 * It doesn't matter that we use Element<BasicProperty> here because we just need the name of the property.
                 */

                var content = (IPublishedContent?) elementType.GetProperty(nameof(Element<BasicProperty>.Content))?.GetValue(element);

                if (content == null)
                {
                    return default;
                }

                var culture = (string?) elementType.GetProperty(nameof(Element<BasicProperty>.Culture))?.GetValue(element);

                var segment = (string?) elementType.GetProperty(nameof(Element<BasicProperty>.Segment))?.GetValue(element);

                var fallback = (Fallback?) elementType.GetProperty(nameof(Element<BasicProperty>.Fallback))?.GetValue(element);

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
}