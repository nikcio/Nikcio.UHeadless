using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Examples.Docs.PropertyValues {
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
