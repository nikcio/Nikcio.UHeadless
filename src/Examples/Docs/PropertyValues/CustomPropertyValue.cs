using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;

namespace Examples.Docs.PropertyValues {
    public class CustomPropertyValue : PropertyValue {

        public string? Name { get; set; }

        public CustomPropertyValue(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value == null) return;
            Name = (string) value;
        }
    }
}
