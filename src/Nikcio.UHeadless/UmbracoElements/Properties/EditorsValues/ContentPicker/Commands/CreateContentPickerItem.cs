using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.ContentPicker.Commands {
    /// <summary>
    /// A command for creating a content picker item
    /// </summary>
    public class CreateContentPickerItem {
        /// <inheritdoc/>
        public CreateContentPickerItem(IPublishedContent publishedContent) {
            PublishedContent = publishedContent;
        }

        /// <summary>
        /// The published content
        /// </summary>
        public virtual IPublishedContent PublishedContent { get; set; }
    }
}
