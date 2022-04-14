﻿using HotChocolate;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Models
{
    /// <summary>
    /// Represents a media item
    /// </summary>
    [GraphQLDescription("Represents a media item.")]
    public class BasicMediaItem
    {
        /// <summary>
        /// Gets the absolute url of a media item
        /// </summary>
        [GraphQLDescription("Gets the absolute url of a media item.")]
        public virtual string Url { get; set; }

        /// <inheritdoc/>
        public BasicMediaItem(IPublishedContent publishedContent, string culture)
        {
            Url = publishedContent.MediaUrl(culture: culture, mode: UrlMode.Absolute);
        }
    }
}