using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Elements.Commands
{
    /// <summary>
    /// A command to create a element
    /// </summary>
    public class CreateElement
    {
        /// <inheritdoc/>
        public CreateElement(IPublishedContent content, string? culture)
        {
            Content = content;
            Culture = culture;
        }

        /// <summary>
        /// The published content
        /// </summary>
        public IPublishedContent Content { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public string? Culture { get; set; }
    }
}
