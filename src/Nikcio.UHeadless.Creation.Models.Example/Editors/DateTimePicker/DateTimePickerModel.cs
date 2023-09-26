using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.DateTimePicker;

/// <summary>
/// Represents a date time property value
/// </summary>
public class DateTimePickerModel : PropertyValue
{
    /// <summary>
    /// Gets the value of the property
    /// </summary>
    public virtual DateTime? Value { get; set; }

    /// <inheritdoc/>
    public DateTimePickerModel(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        var value = createPropertyValue.Property.Value<DateTime?>(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);

        if (value == default(DateTime))
        {
            Value = null;
        } else
        {
            Value = value;
        }
    }
}
