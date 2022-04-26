using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Models {
    /// <summary>
    /// Represents a media item
    /// </summary>
    [GraphQLDescription("Represents a media item.")]
    public class BasicMediaPickerItem : MediaPickerItem {
        /// <summary>
        /// Gets the absolute url of a media item
        /// </summary>
        [GraphQLDescription("Gets the absolute url of a media item.")]
        public virtual string Url { get; set; }

        /// <inheritdoc/>
        public BasicMediaPickerItem(CreateMediaPickerItem createMediaPickerItem) : base(createMediaPickerItem) {
            Url = createMediaPickerItem.PublishedContent.MediaUrl(culture: createMediaPickerItem.Culture, mode: UrlMode.Absolute);
        }
    }
}