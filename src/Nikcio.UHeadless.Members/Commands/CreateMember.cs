using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Commands {
    /// <summary>
    /// A command to create a member
    /// </summary>
    public class CreateMember : ICommand {
        /// <inheritdoc/>
        public CreateMember(IPublishedContent? member, CreateElement createElement) {
            Member = member;
            CreateElement = createElement;
        }

        /// <summary>
        /// The member
        /// </summary>
        public virtual IPublishedContent? Member { get; set; }

        /// <summary>
        /// The create element command
        /// </summary>
        public virtual CreateElement CreateElement { get; set; }
    }
}
