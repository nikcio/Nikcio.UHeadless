using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Factories {
    /// <inheritdoc/>
    public class ContentRedirectFactory<TContentRedirect> : IContentRedirectFactory<TContentRedirect>
        where TContentRedirect : IContentRedirect {

        /// <summary>
        /// A factory for creating models with DI and reflection
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public ContentRedirectFactory(IDependencyReflectorFactory dependencyReflectorFactory) {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual TContentRedirect? CreateContentRedirect(CreateContentRedirect createContentRedirect) {

            var createdContent = dependencyReflectorFactory.GetReflectedType<IContentRedirect>(typeof(TContentRedirect), new object[] { createContentRedirect });
            if (createdContent == null) {
                return default;
            }
            return (TContentRedirect) createdContent;
        }
    }
}
