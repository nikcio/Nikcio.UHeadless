using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Commands {
    /// <summary>
    /// Command for creating a property value
    /// </summary>
    public class CreatePropertyValue {
        /// <inheritdoc/>
        public CreatePropertyValue(IPublishedContent content, IPublishedProperty property, string culture) {
            Content = content;
            Property = property;
            Culture = culture;
        }

        /// <summary>
        /// The <see cref="IPublishedContent"/>
        /// </summary>
        public virtual IPublishedContent Content { get; set; }

        /// <summary>
        /// The <see cref="IPublishedProperty"/>
        /// </summary>
        public virtual IPublishedProperty Property { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string Culture { get; set; }
    }
}
