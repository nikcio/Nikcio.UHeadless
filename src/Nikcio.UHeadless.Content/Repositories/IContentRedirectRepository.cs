using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;

namespace Nikcio.UHeadless.Content.Repositories {
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