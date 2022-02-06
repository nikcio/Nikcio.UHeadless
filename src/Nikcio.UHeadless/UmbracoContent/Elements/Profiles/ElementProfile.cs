using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Profiles
{
    public class ElementProfile : Profile
    {
        public ElementProfile()
        {
            CreateMap<IPublishedElement, PublishedElementGraphType>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));
        }
    }
}
