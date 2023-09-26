using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Creation.Models.Example.Properties;

/// <inheritdoc/>
public class PropertyModel : Property
{
    private readonly CreatePropertyValue _createPropertyValue;

    /// <inheritdoc/>
    public PropertyModel(CreateProperty createProperty, IPropertyValueFactory propertyValueFactory) : base(createProperty)
    {
        publishedProperty = createProperty.PublishedProperty;
        this.propertyValueFactory = propertyValueFactory;
        _createPropertyValue = new CreatePropertyValue(createProperty.PublishedContent, createProperty.PublishedProperty, createProperty.Culture, createProperty.Segment, createProperty.PublishedValueFallback, createProperty.Fallback);

        Alias = publishedProperty.Alias;
        ValueObject = propertyValueFactory.GetPropertyValue(_createPropertyValue);
        EditorAlias = publishedProperty.PropertyType.EditorAlias;
    }

    /// <inheritdoc/>
    public virtual string Alias { get; }

    /// <inheritdoc/>
    public virtual string EditorAlias { get; }

    /// <inheritdoc/>
    public virtual PropertyValue? ValueObject { get; }

    /// <summary>
    /// The published property
    /// </summary>
    protected readonly IPublishedProperty publishedProperty;

    /// <summary>
    /// A factory for creating property values
    /// </summary>
    protected readonly IPropertyValueFactory propertyValueFactory;
}
