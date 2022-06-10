using Nikcio.UHeadless.Basics.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Properties.Commands;
using Nikcio.UHeadless.Properties.Models;

namespace Examples.Docs.PropertyValues {
    public class CustomBlockListModel : BasicBlockListModel<BasicBlockListItem<BasicProperty>> {

        public string MyCustomProperty { get; set; }

        public CustomBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
            MyCustomProperty = "Hello I'm Custom!";
        }
    }
}
