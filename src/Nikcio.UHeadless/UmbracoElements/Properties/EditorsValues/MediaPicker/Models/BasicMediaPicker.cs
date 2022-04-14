using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Models {
    /// <summary>
    /// Represents a media picker item
    /// </summary>
    [GraphQLDescription("Represents a media picker item.")]
    public class BasicMediaPicker : PropertyValue {
        /// <summary>
        /// Gets the media items of a picker
        /// </summary>
        [GraphQLDescription("Gets the media items of a picker.")]
        public virtual List<BasicMediaItem> MediaItems { get; set; } = new();

        /// <inheritdoc/>
        public BasicMediaPicker(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value is IPublishedContent mediaItem) {
                MediaItems.Add(new BasicMediaItem(mediaItem, createPropertyValue.Culture));
            } else if (value != null) {
                var mediaItems = (IEnumerable<IPublishedContent>) value;
                if (mediaItems != null && mediaItems.Any()) {
                    foreach (var media in mediaItems) {
                        MediaItems.Add(new BasicMediaItem(media, createPropertyValue.Culture));
                    }
                }
            }
        }
    }
}
