using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Base.Basics.EditorsValues.Labels.Models {
    /// <summary>
    /// Represents a label property value
    /// </summary>
    [GraphQLDescription("Represents a date time property value.")]
    public class BasicLabel : PropertyValue {
        /// <summary>
        /// Gets the value of the property
        /// </summary>
        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of the property.")]
        public virtual object? Value { get; set; }

        /// <inheritdoc/>
        public BasicLabel(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value != null) {
                if (value is DateTime dateTimeValue) {
                    Value = dateTimeValue;
                    if ((DateTime) Value == default) {
                        Value = null;
                    }
                } else {
                    Value = value;
                }
            }
        }
    }
}
