using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a block list item.")]
    public class BlockListItemGraphType<TPropertyGraphType> : BlockListItemBaseGraphType
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        /// <inheritdoc/>
        public BlockListItemGraphType(CreateBlockListItem createBlockListItem, IPropertyFactory<TPropertyGraphType> propertyFactory) : base(createBlockListItem)
        {
            if (createBlockListItem.BlockListItem == null)
            {
                return;
            }
            if (createBlockListItem.Content != null)
            {
                foreach (var property in createBlockListItem.BlockListItem.Content.Properties)
                {
                    ContentProperties.Add(propertyFactory.GetPropertyGraphType(property, createBlockListItem.Content, createBlockListItem.Culture));
                }

                if (createBlockListItem.BlockListItem.Settings != null)
                {
                    foreach (var property in createBlockListItem.BlockListItem.Settings.Properties)
                    {
                        SettingsProperties.Add(propertyFactory.GetPropertyGraphType(property, createBlockListItem.Content, createBlockListItem.Culture));
                    }
                }
            }
        }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the content properties of the block list item.")]
        public virtual List<TPropertyGraphType> ContentProperties { get; set; } = new List<TPropertyGraphType>();

        /// <inheritdoc/>
        [GraphQLDescription("Gets the setting properties of the block list item.")]
        public virtual List<TPropertyGraphType> SettingsProperties { get; set; } = new List<TPropertyGraphType>();
    }
}