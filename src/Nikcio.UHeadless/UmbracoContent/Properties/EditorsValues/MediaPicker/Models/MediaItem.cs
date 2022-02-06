using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MediaPicker.Models
{
    public class MediaItem
    {
        public string Url { get; set; }

        public MediaItem(IPublishedContent publishedContent, string culture)
        {
            Url = publishedContent.MediaUrl(culture: culture, mode: UrlMode.Absolute);
        }
    }
}