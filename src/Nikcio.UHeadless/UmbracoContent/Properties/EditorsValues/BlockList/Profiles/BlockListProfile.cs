using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Profiles
{
    /// <summary>
    /// The block list profile
    /// </summary>
    public class BlockListProfile : Profile
    {
        /// <inheritdoc/>
        public BlockListProfile()
        {
            CreateMap<BlockListItem, BlockListItemGraphType<PropertyGraphType>>(); // TODO
        }
    }
}
