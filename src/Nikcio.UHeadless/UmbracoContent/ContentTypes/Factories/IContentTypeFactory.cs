using Nikcio.UHeadless.UmbracoContent.ContentTypes.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Factories
{
    public interface IContentTypeFactory<TContentType>
        where TContentType : IContentType
    {
        TContentType? CreateContentType(IPublishedContentType publishedContentType);
    }
}