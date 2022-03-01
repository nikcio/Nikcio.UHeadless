using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MediaPicker.Models
{
    [GraphQLDescription("Represents a media picker item.")]
    public class MediaPickerGraphType : PropertyValueBaseGraphType
    {
        [GraphQLDescription("Gets the media items of a picker.")]
        public virtual List<MediaItem> MediaItems { get; set; } = new();

        public MediaPickerGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value is IPublishedContent mediaItem)
            {
                MediaItems.Add(new MediaItem(mediaItem, createPropertyValue.Culture));
            }
            else if (value != null)
            {
                var mediaItems = (IEnumerable<IPublishedContent>)value;
                if (mediaItems != null && mediaItems.Any())
                {
                    foreach (var media in mediaItems)
                    {
                        MediaItems.Add(new MediaItem(media, createPropertyValue.Culture));
                    }
                }
            }
        }
    }
}
