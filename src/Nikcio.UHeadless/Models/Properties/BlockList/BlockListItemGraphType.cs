using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using AutoMapper;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Factories.Properties;

namespace Nikcio.UHeadless.Models.Properties
{
    public class BlockListItemGraphType
    {
        public BlockListItemGraphType(BlockListItem blockListItem, IMapper mapper, IPropertyFactory propertyFactory)
        {
            ContentUdi = blockListItem.ContentUdi;
            Content = mapper.Map<PublishedElementGraphType>(blockListItem.Content);
            if(Content != null)
            {
                foreach (var property in blockListItem.Content.Properties)
                {
                    propertyFactory.AddProperty(Content, property);
                }
            }
            SettingsUdi = blockListItem.SettingsUdi;
            Settings = mapper.Map<PublishedElementGraphType>(blockListItem.Settings);
            if(Settings != null)
            {
                foreach (var property in blockListItem.Settings.Properties)
                {
                    propertyFactory.AddProperty(Settings, property);
                }
            }
        }

        public Udi ContentUdi { get; }

        public PublishedElementGraphType Content { get; }


        public Udi SettingsUdi { get; }

        public PublishedElementGraphType Settings { get; }
    }
}