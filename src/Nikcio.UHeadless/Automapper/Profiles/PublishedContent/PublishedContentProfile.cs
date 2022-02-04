using AutoMapper;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Automapper.Profiles.PublishedContent
{
    public class PublishedContentProfile : Profile
    {
        public PublishedContentProfile()
        {
            CreateMap<IPublishedContent, PublishedContentGraphType>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));

            CreateMap<IPublishedContentType, PublishedContentTypeGraphType>();

            CreateMap<IPublishedElement, PublishedElementGraphType>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter()
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));
        }
    }
}
