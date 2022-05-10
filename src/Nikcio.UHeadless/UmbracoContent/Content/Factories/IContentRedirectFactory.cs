using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Factories {
    /// <summary>
    /// A factory for creating a content redirect
    /// </summary>
    /// <typeparam name="TContentRedirect"></typeparam>
    public interface IContentRedirectFactory<TContentRedirect>
        where TContentRedirect : IContentRedirect {

        /// <summary>
        /// Creates a content redirect
        /// </summary>
        /// <param name="createContentRedirect"></param>
        /// <returns></returns>
        TContentRedirect? CreateContentRedirect(CreateContentRedirect createContentRedirect);
    }
}