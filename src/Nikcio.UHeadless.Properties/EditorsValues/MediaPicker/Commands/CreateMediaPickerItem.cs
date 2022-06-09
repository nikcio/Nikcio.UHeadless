using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Properties.EditorsValues.MediaPicker.Commands {
    /// <summary>
    /// A command to create a media picker item
    /// </summary>
    public class CreateMediaPickerItem {
        /// <inheritdoc/>
        public CreateMediaPickerItem(IPublishedContent publishedContent, string culture) {
            PublishedContent = publishedContent;
            Culture = culture;
        }

        /// <summary>
        /// The published conten
        /// </summary>
        public virtual IPublishedContent PublishedContent { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string Culture { get; set; }
    }
}
