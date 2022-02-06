using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Profiles
{
    public class ContentProfile : Profile
    {
        public ContentProfile()
        {
            CreateMap<IPublishedContent, ContentGraphType>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));
        }
    }
}
