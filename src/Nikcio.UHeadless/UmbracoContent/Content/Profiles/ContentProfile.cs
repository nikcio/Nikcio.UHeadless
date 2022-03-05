using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Profiles
{
    /// <summary>
    /// The profile for content
    /// </summary>
    public class ContentProfile : Profile
    {
        /// <inheritdoc/>
        public ContentProfile()
        {
            CreateMap<IPublishedContent, ContentGraphType<PropertyGraphType>>() //TODO
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));
        }
    }
}
