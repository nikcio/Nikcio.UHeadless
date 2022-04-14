using Nikcio.UHeadless.UmbracoContent.ContentTypes.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Models
{
    /// <inheritdoc/>
    public abstract class ContentType : IContentType
    {
        /// <inheritdoc/>
        public ContentType(CreateContentType createContentType)
        {
            PublishedContentType = createContentType.PublishedContentType;
        }

        /// <summary>
        /// THe publised content type
        /// </summary>
        protected IPublishedContentType PublishedContentType { get; }
    }
}
