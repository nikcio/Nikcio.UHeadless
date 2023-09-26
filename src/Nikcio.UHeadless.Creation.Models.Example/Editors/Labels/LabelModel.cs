using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.Labels;

/// <summary>
/// Represents a label property value
/// </summary>
public class LabelModel : PropertyValue
{
    /// <summary>
    /// Gets the value of the property
    /// </summary>
    public virtual object? Value { get; set; }

    /// <inheritdoc/>
    public LabelModel(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        var value = createPropertyValue.Property.Value(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (value != null)
        {
            if (value is DateTime dateTimeValue)
            {
                if (dateTimeValue == default)
                {
                    Value = null;
                } else
                {
                    Value = dateTimeValue;
                }
            } else
            {
                Value = value;
            }
        }
    }
}
