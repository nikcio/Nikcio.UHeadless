using Nikcio.UHeadless.Core.Commands;
using Nikcio.UHeadless.Elements.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Content.Commands {
    /// <summary>
    /// A command to create content
    /// </summary>
    public class CreateContent : ICommand {
        /// <inheritdoc/>
        public CreateContent(IPublishedContent? content, string? culture, CreateElement createElement) {
            Content = content;
            Culture = culture;
            CreateElement = createElement;
        }

        /// <summary>
        /// THe published content
        /// </summary>
        public virtual IPublishedContent? Content { get; set; }

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
