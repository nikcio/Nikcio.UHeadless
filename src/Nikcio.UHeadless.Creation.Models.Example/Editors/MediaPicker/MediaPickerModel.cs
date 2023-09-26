using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MediaPicker.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.MediaPicker;

/// <summary>
/// Represents a media picker item
/// </summary>
public class MediaPickerModel : PropertyValue
{
    /// <summary>
    /// Gets the media items of a picker
    /// </summary>
    public virtual List<MediaPickerItemModel> MediaItems { get; set; } = new();

    /// <inheritdoc/>
    public MediaPickerModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
    {
        var value = createPropertyValue.Property.Value(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (value is IPublishedContent mediaItem)
        {
            AddMediaPickerItem(dependencyReflectorFactory, mediaItem, createPropertyValue.Culture);
        } else if (value is IEnumerable<IPublishedContent> mediaItems && mediaItems.Any())
        {
            foreach (var media in mediaItems)
            {
                AddMediaPickerItem(dependencyReflectorFactory, media, createPropertyValue.Culture);
            }
        }
    }

    /// <summary>
    /// Adds a media picker item to media items
    /// </summary>
    /// <param name="dependencyReflectorFactory"></param>
    /// <param name="media"></param>
    /// <param name="culture"></param>
    protected void AddMediaPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedContent media, string? culture)
    {
        var mediaPickerItem = dependencyReflectorFactory.GetReflectedType<MediaPickerItemModel>(typeof(MediaPickerItemModel), new object[] { new CreateMediaPickerItem(media, culture) });
        if (mediaPickerItem != null)
        {
            MediaItems.Add(mediaPickerItem);
        }
    }
}
