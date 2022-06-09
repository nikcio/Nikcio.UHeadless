using Nikcio.UHeadless.Elements.Commands;

namespace Nikcio.UHeadless.Media.Commands {
    /// <summary>
    /// A command to create media
    /// </summary>
    public class CreateMedia {
        /// <inheritdoc/>
        public CreateMedia(IPublishedContent media, string? culture, CreateElement createElement) {
            Media = media;
            Culture = culture;
            CreateElement = createElement;
        }

        /// <summary>
        /// The published media
        /// </summary>
        public virtual IPublishedContent Media { get; set; }

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
