using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Base.Basics.EditorsValues.Grid.Models {

    /// <summary>
    /// Represents a grid edtior
    /// </summary>
    [GraphQLDescription("Represents a grid editor.")]
    public class BasicGrid : PropertyValue {
        /// <summary>
        /// Gets the value of the grid editor
        /// </summary>
        [GraphQLDescription("Gets the value of the grid editor.")]
        public virtual string? Value { get; set; }

        /// <inheritdoc/>
        public BasicGrid(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            var propertyValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (propertyValue == null) {
                return;
            }
            Value = ((string) propertyValue)?.ToString();
        }
    }
}
