using Nikcio.UHeadless.UmbracoContent.Elements.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Commands
{
    /// <summary>
    /// A command to create media
    /// </summary>
    public class CreateMedia
    {
        /// <inheritdoc/>
        public CreateMedia(IPublishedContent media, string? culture, CreateElement createElement)
        {
            Media = media;
            Culture = culture;
            CreateElement = createElement;
        }

        /// <summary>
        /// The published media
        /// </summary>
        public IPublishedContent Media { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public string? Culture { get; set; }

        /// <summary>
        /// The create element command
        /// </summary>
        public CreateElement CreateElement { get; set; }
    }
}
