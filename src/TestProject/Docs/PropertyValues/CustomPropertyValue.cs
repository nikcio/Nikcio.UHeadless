using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;

namespace TestProject.Docs.PropertyValues {
    public class CustomPropertyValue : PropertyValue {

        public string Name { get; set; }

        public CustomPropertyValue(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            Name = (string) createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        }
    }
}
