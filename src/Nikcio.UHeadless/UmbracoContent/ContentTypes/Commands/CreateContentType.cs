using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Commands
{
    public class CreateContentType
    {
        public CreateContentType(IPublishedContentType publishedContentType)
        {
            PublishedContentType = publishedContentType;
        }

        public IPublishedContentType PublishedContentType { get; set; }
    }
}
