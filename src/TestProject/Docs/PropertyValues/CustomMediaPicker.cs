using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Models;

namespace TestProject.Docs.PropertyValues {
    public class CustomMediaPicker : BasicMediaPicker {

        public string MyCustomProperty { get; set; }

        public CustomMediaPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
            MyCustomProperty = "Here's a custom property";
        }
    }

    public class CustomMediaPicker2 : BasicMediaPicker<BasicMediaPickerItem> {

        public string MyCustomProperty { get; set; }

        public CustomMediaPicker2(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
            MyCustomProperty = "Here's a custom property2";
        }
    }
}
