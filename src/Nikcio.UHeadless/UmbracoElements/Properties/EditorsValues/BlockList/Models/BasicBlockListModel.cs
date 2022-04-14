using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.BlockList.Commands;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.BlockList.Models {
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
            var value = (BlockListModel) createPropertyValue.Property.GetValue();
            Blocks = value?.Select(blockListItem => {
                var type = typeof(T);
                return dependencyReflectorFactory.GetReflectedType<T>(type, new object[] { new CreateBlockListItem(createPropertyValue.Content, blockListItem, createPropertyValue.Culture) });
            }).OfType<T>().ToList();
        }
    }
}
