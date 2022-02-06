using HotChocolate;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MediaPicker.Models
{
    [GraphQLDescription("Represents a media item.")]
    public class MediaItem
    {
        [GraphQLDescription("Gets the absolute url of a media item.")]
        public string Url { get; set; }

        public MediaItem(IPublishedContent publishedContent, string culture)
        {
            Url = publishedContent.MediaUrl(culture: culture, mode: UrlMode.Absolute);
        }
    }
}