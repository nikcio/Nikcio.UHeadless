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
                .ForMember(dest => dest.Properties, options => options.Ignore())
                .ForMember(dest => dest.Children, options => options.Ignore())
                .ForMember(dest => dest.ChildrenForAllCultures, options => options.Ignore())
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));

            CreateMap<IPublishedContentType, PublishedContentTypeGraphType>();

            CreateMap<IPublishedElement, PublishedElementGraphType>()
                .ForMember(dest => dest.Properties, options => options.Ignore())
                .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src));
        }
    }
}
