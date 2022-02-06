using System.Collections.Generic;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Models
{
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

        public List<PropertyGraphType> ContentProperties { get; set; } = new List<PropertyGraphType>();

        public List<PropertyGraphType> SettingsProperties { get; set; } = new List<PropertyGraphType>();
    }
}