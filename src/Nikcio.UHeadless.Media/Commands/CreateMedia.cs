using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Media.Commands {
    /// <summary>
    /// A command to create media
    /// </summary>
    public class CreateMedia : ICommand {
        /// <inheritdoc/>
        public CreateMedia(IPublishedContent? media, string? culture, CreateElement createElement) {
            Media = media;
            Culture = culture;
            CreateElement = createElement;
        }

        /// <summary>
        /// The published media
        /// </summary>
        public virtual IPublishedContent? Media { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string? Culture { get; set; }

        /// <summary>
        /// The create element command
        /// </summary>
        public virtual CreateElement CreateElement { get; set; }
    }
}
