using AutoMapper;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Nikcio.UHeadless.Models.Dtos.Elements;
using System.Collections.Generic;
using System.Linq;
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
