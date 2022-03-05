using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands
{
    /// <summary>
    /// Command for creating an element
    /// </summary>
    public class CreateElement
    {
        /// <inheritdoc/>
        public CreateElement(IPublishedContent content, IPublishedElement element, string culture)
        {
            Content = content;
            Element = element;
            Culture = culture;
        }

        /// <summary>
        /// The <see cref="IPublishedContent"/>
        /// </summary>
        public virtual IPublishedContent Content { get; set; }

        /// <summary>
        /// The <see cref="IPublishedElement"/>
        /// </summary>
        public virtual IPublishedElement Element { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string Culture { get; set; }
    }
}
