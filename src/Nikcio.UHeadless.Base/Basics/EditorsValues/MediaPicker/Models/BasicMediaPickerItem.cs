﻿using HotChocolate;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MediaPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MediaPicker.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MediaPicker.Models;

/// <summary>
/// Represents a media item
/// </summary>
[GraphQLDescription("Represents a media item.")]
public class BasicMediaPickerItem : MediaPickerItem
{
    /// <summary>
    /// Gets the absolute url of a media item
    /// </summary>
    [GraphQLDescription("Gets the absolute url of a media item.")]
    public virtual string Url { get; set; }

    /// <summary>
    /// Gets the id of a media item
    /// </summary>
    [GraphQLDescription("Gets the id of a media item.")]
    public virtual int Id { get; set; }

    /// <inheritdoc/>
    public BasicMediaPickerItem(CreateMediaPickerItem createMediaPickerItem) : base(createMediaPickerItem)
    {
        // As of version 11.3.1, Umbraco does not support multilingual media type so culture has to be null.
        Url = createMediaPickerItem.PublishedContent.MediaUrl(culture: null, mode: UrlMode.Absolute);
        Id = createMediaPickerItem.PublishedContent.Id;
    }
}
