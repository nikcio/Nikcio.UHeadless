using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Commands {
    /// <summary>
    /// A command to create a member
    /// </summary>
    public class CreateMember : ICommand {
        /// <inheritdoc/>
        public CreateMember(IMember? member) {
            Member = member;
        }

        /// <summary>
        /// The member
        /// </summary>
        public virtual IMember? Member { get; set; }
    }
}
