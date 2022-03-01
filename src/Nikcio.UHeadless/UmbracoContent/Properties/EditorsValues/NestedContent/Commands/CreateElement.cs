using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands
{
    public class CreateElement
    {
        public CreateElement(IPublishedContent content, IPublishedElement element, string culture)
        {
            Content = content;
            Element = element;
            Culture = culture;
        }

        public virtual IPublishedContent Content { get; set; }
        public virtual IPublishedElement Element { get; set; }
        public virtual string Culture { get; set; }
    }
}
