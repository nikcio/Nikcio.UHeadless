using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Commands;

namespace Nikcio.UHeadless.Members.Models {
    /// <summary>
    /// A base for member
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class Member<TProperty> : IMember<TProperty>
        where TProperty : IProperty {
        /// <inheritdoc/>
        protected Member(CreateMember createMember, IPropertyFactory<TProperty> propertyFactory) {
            MemberItem = createMember.Member;
            PropertyFactory = propertyFactory;
        }

        /// <summary>
        /// The propertyFactory
        /// </summary>
        protected virtual IPropertyFactory<TProperty> PropertyFactory { get; }

        /// <summary>
        /// The content
        /// </summary>
        protected virtual Umbraco.Cms.Core.Models.IMember? MemberItem { get; }

        /// <summary>
        /// The culture
        /// </summary>
        protected virtual string? Culture { get; }
    }
}
