using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentType.Profiles
{
    public class ContentTypeProfile : Profile
    {
        public ContentTypeProfile()
        {
            CreateMap<IPublishedContentType, ContentTypeGraphType>();
        }
    }
}
