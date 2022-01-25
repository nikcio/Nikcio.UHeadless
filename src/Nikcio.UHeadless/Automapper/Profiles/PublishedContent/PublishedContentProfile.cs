using AutoMapper;
using Nikcio.UHeadless.Dtos.Content;
using Nikcio.UHeadless.Dtos.ContentTypes;
using Nikcio.UHeadless.Dtos.Elements;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Automapper.Profiles.PublishedContent
{
    public class PublishedContentProfile : Profile
    {
        public PublishedContentProfile()
        {
            CreateMap<IPublishedContent, PublishedContentGraphType>()
                .ForMember(nameof(IPublishedContent.Properties), options => options.Ignore());

            CreateMap<IPublishedContentType, PublishedContentTypeGraphType>();

            CreateMap<IPublishedElement, PublishedElementGraphType>()
                .ForMember(nameof(IPublishedContent.Properties), options => options.Ignore());
        }
    }
}
