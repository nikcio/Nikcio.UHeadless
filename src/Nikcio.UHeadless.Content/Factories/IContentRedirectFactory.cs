using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;

namespace Nikcio.UHeadless.Content.Factories {
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