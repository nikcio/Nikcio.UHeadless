using AutoMapper;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentType.Profiles
{
    /// <summary>
    /// The content type profile
    /// </summary>
    public class ContentTypeProfile : Profile
    {
        ///<inheritdoc/>
        public ContentTypeProfile()
        {
            CreateMap<IPublishedContentType, ContentTypeGraphType>();
        }
    }
}
