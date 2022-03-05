using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoMedia.Media.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Profiles
{
    /// <summary>
    /// The profile for Media
    /// </summary>
    public class MediaProfile : Profile
    {
        /// <inheritdoc/>
        public MediaProfile()
        {
            CreateMap<IPublishedContent, MediaGraphType<PropertyGraphType>>() //TODO
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));
        }
    }
}
