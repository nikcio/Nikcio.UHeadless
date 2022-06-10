using HotChocolate;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.MediaPicker.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.MediaPicker.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MediaPicker.Models {
    /// <summary>
    /// Represents a media picker item
    /// </summary>
    [GraphQLDescription("Represents a media picker item.")]
    public class BasicMediaPicker : BasicMediaPicker<BasicMediaPickerItem> {
        /// <inheritdoc/>
        public BasicMediaPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a media picker item
    /// </summary>
    [GraphQLDescription("Represents a media picker item.")]
    public class BasicMediaPicker<TMediaItem> : PropertyValue
        where TMediaItem : MediaPickerItem {
        /// <summary>
        /// Gets the media items of a picker
        /// </summary>
        [GraphQLDescription("Gets the media items of a picker.")]
        public virtual List<TMediaItem> MediaItems { get; set; } = new();

        /// <inheritdoc/>
        public BasicMediaPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value is IPublishedContent mediaItem) {
                AddMediaPickerItem(dependencyReflectorFactory, mediaItem, createPropertyValue.Culture);
            } else if (value != null) {
                var mediaItems = (IEnumerable<IPublishedContent>) value;
                if (mediaItems != null && mediaItems.Any()) {
                    foreach (var media in mediaItems) {
                        AddMediaPickerItem(dependencyReflectorFactory, media, createPropertyValue.Culture);
                    }
                }
            }
        }


        /// <summary>
        /// Adds a media picker item to media items
        /// </summary>
        /// <param name="dependencyReflectorFactory"></param>
        /// <param name="media"></param>
        /// <param name="culture"></param>
        protected virtual void AddMediaPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedContent media, string culture) {
            var mediaPickerItem = dependencyReflectorFactory.GetReflectedType<TMediaItem>(typeof(TMediaItem), new object[] { new CreateMediaPickerItem(media, culture) });
            if (mediaPickerItem != null) {
                MediaItems.Add(mediaPickerItem);
            }
        }
    }
}
