using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Models
{
    [GraphQLDescription("Represents a block list item.")]
    public class BlockListItemGraphType : BlockListItemBaseGraphType
    {
        public BlockListItemGraphType(CreateBlockListItem createBlockListItem, IPropertyFactory propertyFactory) : base(createBlockListItem)
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
            }
            if (createBlockListItem.BlockListItem.Settings != null)
            {
                foreach (var property in createBlockListItem.BlockListItem.Settings.Properties)
                {
                    SettingsProperties.Add(propertyFactory.GetPropertyGraphType(property, createBlockListItem.Content, createBlockListItem.Culture));
                }
            }
        }

        [GraphQLDescription("Gets the content properties of the block list item.")]
        public List<PropertyGraphType> ContentProperties { get; set; } = new List<PropertyGraphType>();

        [GraphQLDescription("Gets the setting properties of the block list item.")]
        public List<PropertyGraphType> SettingsProperties { get; set; } = new List<PropertyGraphType>();
    }
}