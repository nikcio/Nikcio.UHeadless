using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Commands
{
    public class CreateElement
    {
        public CreateElement(IPublishedContent content, string? culture)
        {
            Content = content;
            Culture = culture;
        }

        public IPublishedContent Content { get; set; }
        public string? Culture { get; set; }
    }
}
