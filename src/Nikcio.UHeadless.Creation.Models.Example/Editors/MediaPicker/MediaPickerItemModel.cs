using Nikcio.UHeadless.Base.Properties.EditorsValues.MediaPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MediaPicker.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.MediaPicker;

/// <summary>
/// Represents a media item
/// </summary>
public class MediaPickerItemModel : MediaPickerItem
{
    /// <summary>
    /// Gets the absolute url of a media item
    /// </summary>
    public virtual string Url { get; set; }

    /// <summary>
    /// Gets the id of a media item
    /// </summary>
    public virtual int Id { get; set; }

    /// <inheritdoc/>
    public MediaPickerItemModel(CreateMediaPickerItem createMediaPickerItem) : base(createMediaPickerItem)
    {
        Url = createMediaPickerItem.PublishedContent.MediaUrl(mode: UrlMode.Absolute);
        Id = createMediaPickerItem.PublishedContent.Id;
    }
}
