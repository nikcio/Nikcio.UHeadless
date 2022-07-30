using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;

namespace Nikcio.UHeadless.Members.Basics.Models {
    /// <summary>
    /// Represents a member
    /// </summary>
    public class BasicMember : Member<BasicProperty> {
        /// <inheritdoc/>
        public BasicMember(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory) {
        }

        /// <summary>
        /// The member id
        /// </summary>
        public int? Id => MemberItem?.Id;
    }
}
