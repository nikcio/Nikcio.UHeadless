using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Properties.Commands {
    /// <summary>
    /// A command for creating a property
    /// </summary>
    public class CreateProperty {
        /// <inheritdoc/>
        public CreateProperty(IPublishedProperty publishedProperty, string? culture, IPublishedContent publishedContent) {
            PublishedProperty = publishedProperty;
            Culture = culture;
            PublishedContent = publishedContent;
        }

        /// <summary>
        /// The culture
        /// </summary>
        public string? Culture { get; }

        /// <summary>
        /// The published content
        /// </summary>
        public IPublishedContent PublishedContent { get; }

        /// <summary>
        /// The published property
        /// </summary>
        public IPublishedProperty PublishedProperty { get; }
    }
}
