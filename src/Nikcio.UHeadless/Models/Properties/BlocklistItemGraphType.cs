using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using AutoMapper;
using Nikcio.UHeadless.Models.Dtos.Elements;

namespace Nikcio.UHeadless.Models.Properties
{
    public class BlocklistItemGraphType
    {
        public BlocklistItemGraphType(BlockListItem blockListItem, IMapper mapper)
        {
            ContentUdi = blockListItem.ContentUdi;
            Content = mapper.Map<PublishedElementGraphType>(blockListItem.Content);
            SettingsUdi = blockListItem.SettingsUdi;
            Settings = mapper.Map<PublishedElementGraphType>(blockListItem.Settings);
        }

        public Udi ContentUdi { get; }

        public PublishedElementGraphType Content { get; }


        public Udi SettingsUdi { get; }

        public PublishedElementGraphType Settings { get; }
    }
}