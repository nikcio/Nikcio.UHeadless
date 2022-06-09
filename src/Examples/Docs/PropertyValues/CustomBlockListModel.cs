using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Examples.Docs.PropertyValues {
    public class CustomBlockListModel : BasicBlockListModel<BasicBlockListItem<BasicProperty>> {

        public string MyCustomProperty { get; set; }

        public CustomBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
            MyCustomProperty = "Hello I'm Custom!";
        }
    }
}
