using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands
{
    public class CreatePropertyValue
    {
        public CreatePropertyValue(IPublishedContent content, IPublishedProperty property, string culture)
        {
            Content = content;
            Property = property;
            Culture = culture;
        }

        public virtual IPublishedContent Content { get; set; }
        public virtual IPublishedProperty Property { get; set; }
        public virtual string Culture { get; set; }
    }
}
