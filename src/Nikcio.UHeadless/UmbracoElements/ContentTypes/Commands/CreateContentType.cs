using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.ContentTypes.Commands
{
    /// <summary>
    /// Command to create a content type
    /// </summary>
    public class CreateContentType
    {
        /// <inheritdoc/>
        public CreateContentType(IPublishedContentType publishedContentType)
        {
            PublishedContentType = publishedContentType;
        }

        /// <summary>
        /// The published content type
        /// </summary>
        public IPublishedContentType PublishedContentType { get; set; }
    }
}
