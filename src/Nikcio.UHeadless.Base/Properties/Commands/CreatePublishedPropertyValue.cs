using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Commands {
    /// <summary>
    /// Command for creating a property value
    /// </summary>
    public class CreatePublishedPropertyValue : CreatePropertyValue {
        /// <inheritdoc/>
        public CreatePublishedPropertyValue(IPublishedContent content, IPublishedProperty property, string culture) : base(culture) {
            Content = content;
            Property = property;
        }

        /// <summary>
        /// The <see cref="IPublishedContent"/>
        /// </summary>
        public virtual IPublishedContent Content { get; set; }

        /// <summary>
        /// The <see cref="IPublishedProperty"/>
        /// </summary>
        public virtual IPublishedProperty Property { get; set; }
    }
}
