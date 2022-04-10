using Nikcio.UHeadless.UmbracoContent.ContentTypes.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Models
{
    public abstract class ContentType : IContentType
    {
        public ContentType(CreateContentType createContentType)
        {
            PublishedContentType = createContentType.PublishedContentType;
        }

        protected IPublishedContentType PublishedContentType { get; }
    }
}
