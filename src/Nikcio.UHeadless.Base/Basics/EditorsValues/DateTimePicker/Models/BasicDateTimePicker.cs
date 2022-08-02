using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.DateTimePicker.Models {
    /// <summary>
    /// Represents a date time property value
    /// </summary>
    [GraphQLDescription("Represents a date time property value.")]
    public class BasicDateTimePicker : PropertyValue {
        /// <summary>
        /// Gets the value of the property
        /// </summary>
        [GraphQLDescription("Gets the value of the property.")]
        public virtual DateTime? Value { get; set; }

        /// <inheritdoc/>
        public BasicDateTimePicker(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            object? value = createPropertyValue.GetPropertyValue();
            if (value != null) {
                Value = (DateTime) value;
                if (Value == default(DateTime)) {
                    Value = null;
                }
            }
        }
    }
}
