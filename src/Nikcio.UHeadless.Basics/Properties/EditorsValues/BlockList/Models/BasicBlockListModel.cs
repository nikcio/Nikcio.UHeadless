using HotChocolate;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.BlockList.Models;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.BlockList.Models {
    /// <summary>
    /// Represents a block list model
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [GraphQLDescription("Represents a block list model.")]
    public class BasicBlockListModel<T> : PropertyValue
        where T : BlockListItem {
        /// <summary>
        /// Gets the blocks of a block list model
        /// </summary>
        [GraphQLDescription("Gets the blocks of a block list model.")]
        public virtual List<T>? Blocks { get; set; }

        /// <inheritdoc/>
        public BasicBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var propertyValue = createPropertyValue.Property.GetValue();
            if (propertyValue == null) {
                return;
            }
            var value = (Umbraco.Cms.Core.Models.Blocks.BlockListModel) propertyValue;
            Blocks = value?.Select(blockListItem => {
                var type = typeof(T);
                return dependencyReflectorFactory.GetReflectedType<T>(type, new object[] { new CreateBlockListItem(createPropertyValue.Content, blockListItem, createPropertyValue.Culture) });
            }).OfType<T>().ToList();
        }
    }
}
