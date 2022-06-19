using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.BlockList.Models {
    /// <summary>
    /// Represents a block list model
    /// </summary>
    [GraphQLDescription("Represents a block list model.")]
    public class BasicBlockListModel : BasicBlockListModel<BasicBlockListItem> {
        /// <inheritdoc/>
        public BasicBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a block list model
    /// </summary>
    /// <typeparam name="TBlockListItem"></typeparam>
    [GraphQLDescription("Represents a block list model.")]
    public class BasicBlockListModel<TBlockListItem> : PropertyValue
        where TBlockListItem : BlockListItem {
        /// <summary>
        /// Gets the blocks of a block list model
        /// </summary>
        [GraphQLDescription("Gets the blocks of a block list model.")]
        public virtual List<TBlockListItem>? Blocks { get; set; }

        /// <inheritdoc/>
        public BasicBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var propertyValue = createPropertyValue.Property.GetValue();
            if (propertyValue == null) {
                return;
            }
            var value = (Umbraco.Cms.Core.Models.Blocks.BlockListModel) propertyValue;
            Blocks = value?.Select(blockListItem => {
                var type = typeof(TBlockListItem);
                return dependencyReflectorFactory.GetReflectedType<TBlockListItem>(type, new object[] { new CreateBlockListItem(createPropertyValue.Content, blockListItem, createPropertyValue.Culture) });
            }).OfType<TBlockListItem>().ToList();
        }
    }
}
