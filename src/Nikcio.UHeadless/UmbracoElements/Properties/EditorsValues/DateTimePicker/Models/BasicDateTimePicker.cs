using System;
using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.DatePicker.Models {
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
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value != null) {
                Value = (DateTime) value;
                if (Value == default(DateTime)) {
                    Value = null;
                }
            }
        }
    }
}
