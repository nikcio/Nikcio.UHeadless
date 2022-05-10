using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Repositories {
    /// <summary>
    /// A repository to create content redirects
    /// </summary>
    /// <typeparam name="TContentRedirect"></typeparam>
    public interface IContentRedirectRepository<TContentRedirect>
        where TContentRedirect : IContentRedirect {

        /// <summary>
        /// Gets a content redirect model
        /// </summary>
        /// <param name="createContentRedirect"></param>
        /// <returns></returns>
        TContentRedirect? GetContentRedirect(CreateContentRedirect createContentRedirect);
    }
}