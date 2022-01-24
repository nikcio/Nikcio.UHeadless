using AutoMapper;
using Nikcio.Umbraco.Headless.Dtos.Content;
using Nikcio.Umbraco.Headless.Dtos.ContentTypes;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Automapper.Profiles.PublishedContent
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
