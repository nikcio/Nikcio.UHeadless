using System.Runtime.Serialization;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core;
using Nikcio.UHeadless.Dtos.Elements;
using Nikcio.UHeadless.Models;
using Umbraco.Cms.Core.Models.Blocks;
using AutoMapper;

namespace Nikcio.UHeadless.Dtos.Propreties.PropertyValues
{
    public class PropertyValueBlocklistItemGraphType
    {
        public PropertyValueBlocklistItemGraphType(BlockListItem blockListItem, IMapper mapper)
        {
            ContentUdi = blockListItem.ContentUdi;
            Content = mapper.Map<PublishedElementGraphType>(blockListItem.Content as IPublishedElement);
        }

        public Udi ContentUdi { get; }

        public PublishedElementGraphType Content { get; }


        public Udi SettingsUdi { get; }

        public PublishedElementGraphType Settings { get; }
    }
}