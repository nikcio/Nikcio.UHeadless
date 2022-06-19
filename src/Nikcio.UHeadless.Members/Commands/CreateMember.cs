using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Commands {
    /// <summary>
    /// A command to create a member
    /// </summary>
    public class CreateMember : ICommand {
        /// <inheritdoc/>
        public CreateMember(IPublishedContent? member, string? culture, CreateElement createElement) {
            Member = member;
            Culture = culture;
            CreateElement = createElement;
        }

        /// <summary>
        /// The published member
        /// </summary>
        public virtual IPublishedContent? Member { get; set; }

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
