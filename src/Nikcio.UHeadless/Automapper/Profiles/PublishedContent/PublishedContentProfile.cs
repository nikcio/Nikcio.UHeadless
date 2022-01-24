using AutoMapper;
using Nikcio.UHeadless.Dtos.Content;
using Nikcio.UHeadless.Dtos.ContentTypes;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Automapper.Profiles.PublishedContent
{
    public class PublishedContentProfile : Profile
    {
        public PublishedContentProfile()
        {
            CreateMap<IPublishedContent, PublishedContentGraphType>();

            CreateMap<IPublishedContentType, PublishedContentTypeGraphType>();
        }
    }
}
