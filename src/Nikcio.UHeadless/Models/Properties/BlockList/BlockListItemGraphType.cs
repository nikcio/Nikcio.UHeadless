using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using AutoMapper;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Factories.Properties;
using Umbraco.Cms.Core.Models.PublishedContent;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System.Collections.Generic;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using Nikcio.UHeadless.Commands.BlockLists;

namespace Nikcio.UHeadless.Models.Properties.BlockList
{
    public class BlockListItemGraphType : BlockListItemBaseGraphType
    {
        public BlockListItemGraphType(CreateBlockListItem createBlockListItem, IPropertyFactory propertyFactory) : base(createBlockListItem)
        {
            if(createBlockListItem.BlockListItem == null)
            {
                return;
            }
            if(createBlockListItem.Content != null)
            {
                foreach (var property in createBlockListItem.BlockListItem.Content.Properties)
                {
                    ContentProperties.Add(propertyFactory.GetPropertyGraphType(property, createBlockListItem.Content, createBlockListItem.Culture));
                }
            }
            if(createBlockListItem.BlockListItem.Settings != null)
            {
                foreach (var property in createBlockListItem.BlockListItem.Settings.Properties)
                {
                    SettingsProperties.Add(propertyFactory.GetPropertyGraphType(property, createBlockListItem.Content, createBlockListItem.Culture));
                }
            }
        }

        public List<PublishedPropertyGraphType> ContentProperties { get; set; } = new List<PublishedPropertyGraphType>();

        public List<PublishedPropertyGraphType> SettingsProperties { get; set; } = new List<PublishedPropertyGraphType>();
    }
}