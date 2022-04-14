using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.ContentTypes.Factories
{
    /// <summary>
    /// A factory for creating content types
    /// </summary>
    /// <typeparam name="TContentType"></typeparam>
    public interface IContentTypeFactory<out TContentType>
        where TContentType : IContentType
    {
        /// <summary>
        /// Creates a content type
        /// </summary>
        /// <param name="publishedContentType"></param>
        /// <returns></returns>
        TContentType? CreateContentType(IPublishedContentType publishedContentType);
    }
}