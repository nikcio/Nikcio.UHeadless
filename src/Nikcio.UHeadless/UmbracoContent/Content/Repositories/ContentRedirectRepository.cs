using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Factories;
using Nikcio.UHeadless.UmbracoContent.Content.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Repositories {
    /// <inheritdoc/>
    public class ContentRedirectRepository<TContentRedirect> : IContentRedirectRepository<TContentRedirect>
        where TContentRedirect : IContentRedirect {

        /// <summary>
        /// A factory for creating content redirects
        /// </summary>
        protected readonly IContentRedirectFactory<TContentRedirect> contentRedirectFactory;

        /// <inheritdoc/>
        public ContentRedirectRepository(IContentRedirectFactory<TContentRedirect> contentRedirectFactory) {
            this.contentRedirectFactory = contentRedirectFactory;
        }

        /// <inheritdoc/>
        public TContentRedirect? GetContentRedirect(CreateContentRedirect createContentRedirect) {
            return contentRedirectFactory.CreateContentRedirect(createContentRedirect);
        }
    }
}
