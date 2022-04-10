using Nikcio.UHeadless.UmbracoContent.Elements.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Commands
{
    public class CreateContent
    {
        public CreateContent(IPublishedContent content, string? culture, CreateElement createElement)
        {
            Content = content;
            Culture = culture;
            CreateElement = createElement;
        }

        public IPublishedContent Content { get; set; }
        public string? Culture { get; set; }
        public CreateElement CreateElement { get; set; }
    }
}
