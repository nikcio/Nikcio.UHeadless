using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Examples.Docs.PropertyValues {
    public class CustomBlockListModel : BasicBlockListModel<BasicBlockListItem<BasicProperty>> {

        public string MyCustomProperty { get; set; }

        public CustomBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
            MyCustomProperty = "Hello I'm Custom!";
        }
    }
}
