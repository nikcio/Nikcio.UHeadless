using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Members.Factories {
    /// <inheritdoc/>
    public class MemberFactory<TMember, TProperty> : IMemberFactory<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// A factory for creating object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <summary>
        /// A published snapshot
        /// </summary>
        protected readonly IPublishedSnapshot publishedSnapshot;

        /// <inheritdoc/>
        public MemberFactory(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedSnapshot publishedSnapshot) {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
            this.publishedSnapshot = publishedSnapshot;
        }

        /// <inheritdoc/>
        public virtual TMember? CreateMember(Umbraco.Cms.Core.Models.IMember member) {
            var publishedMember = publishedSnapshot.Members?.Get(member);

            var createMemberCommand = new CreateMember(publishedMember);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IMember<TProperty>>(typeof(TMember), new object[] { createMemberCommand });
            return createdContent == null ? default : (TMember) createdContent;
        }
    }
}
