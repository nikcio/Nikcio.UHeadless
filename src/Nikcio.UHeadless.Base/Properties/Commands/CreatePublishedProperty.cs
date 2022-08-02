using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Commands {
    /// <summary>
    /// A command for creating a property
    /// </summary>
    public class CreatePublishedProperty : CreateProperty {
        /// <inheritdoc/>
        public CreatePublishedProperty(IPublishedProperty publishedProperty, string? culture, IPublishedContent publishedContent) : base(culture) {
            PublishedProperty = publishedProperty;
            PublishedContent = publishedContent;
        }

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
