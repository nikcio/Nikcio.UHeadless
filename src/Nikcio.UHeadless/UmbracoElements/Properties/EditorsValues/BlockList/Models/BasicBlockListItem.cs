using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.BlockList.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a block list item.")]
    public class BasicBlockListItem<TProperty> : BlockListItem
        where TProperty : IProperty {
        /// <inheritdoc/>
        public BasicBlockListItem(CreateBlockListItem createBlockListItem, IPropertyFactory<TProperty> propertyFactory) : base(createBlockListItem) {
            if (createBlockListItem.BlockListItem == null) {
                return;
            }
            if (createBlockListItem.Content != null) {
                foreach (var property in createBlockListItem.BlockListItem.Content.Properties) {
                    ContentProperties.Add(propertyFactory.GetProperty(property, createBlockListItem.Content, createBlockListItem.Culture));
                }

                if (createBlockListItem.BlockListItem.Settings != null) {
                    foreach (var property in createBlockListItem.BlockListItem.Settings.Properties) {
                        SettingsProperties.Add(propertyFactory.GetProperty(property, createBlockListItem.Content, createBlockListItem.Culture));
                    }
                }
            }
        }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the content properties of the block list item.")]
        public virtual List<TProperty?> ContentProperties { get; set; } = new();

        /// <inheritdoc/>
        [GraphQLDescription("Gets the setting properties of the block list item.")]
        public virtual List<TProperty?> SettingsProperties { get; set; } = new();
    }
}