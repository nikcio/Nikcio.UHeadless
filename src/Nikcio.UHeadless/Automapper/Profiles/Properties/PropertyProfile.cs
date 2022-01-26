using AutoMapper;
using Nikcio.UHeadless.Models.Properties.BlockList;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.UHeadless.Automapper.Profiles.Properties
{
    public class PropertyProfile : Profile
    {
        public PropertyProfile()
        {
            CreateMap<BlockListItem, BlockListItemGraphType>();
        }
    }
}
