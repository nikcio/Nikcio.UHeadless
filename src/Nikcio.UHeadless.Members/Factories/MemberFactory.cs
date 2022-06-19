using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Factories {
    /// <inheritdoc/>
    public class MemberFactory<TMember, TProperty> : IMemberFactory<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// A factory for creating object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public MemberFactory(IDependencyReflectorFactory dependencyReflectorFactory) {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual TMember? CreateMember(Umbraco.Cms.Core.Models.IMember member) {
            var createMemberCommand = new CreateMember(member);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IMember<TProperty>>(typeof(TMember), new object[] { createMemberCommand });
            return createdContent == null ? default : (TMember) createdContent;
        }
    }
}
