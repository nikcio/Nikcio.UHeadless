using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.Fallback;

/// <summary>
/// Represents a basic property value
/// </summary>
public class FallbackPropertyModel : PropertyValue
{
    /// <summary>
    /// Gets the value of the property
    /// </summary>
    public virtual object? Value { get; set; }

    /// <inheritdoc/>
    public FallbackPropertyModel(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        Value = createPropertyValue.Property.Value(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
    }
}
