using HotChocolate;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MediaPicker.Models
{
    /// <summary>
    /// Represents a media item
    /// </summary>
    [GraphQLDescription("Represents a media item.")]
    public class MediaItem
    {
        /// <summary>
        /// Gets the absolute url of a media item
        /// </summary>
        [GraphQLDescription("Gets the absolute url of a media item.")]
        public virtual string Url { get; set; }

        /// <inheritdoc/>
        public MediaItem(IPublishedContent publishedContent, string culture)
        {
            Url = publishedContent.MediaUrl(culture: culture, mode: UrlMode.Absolute);
        }
    }
}