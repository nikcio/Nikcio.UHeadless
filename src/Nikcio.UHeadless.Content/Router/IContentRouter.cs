using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Umbraco.Cms.Core.Routing;

namespace Nikcio.UHeadless.Content.Router {
    /// <summary>
    /// A router for fetching content
    /// </summary>
    /// <typeparam name="TContent"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TContentRedirect"></typeparam>
    public interface IContentRouter<TContent, TProperty, TContentRedirect>
        where TContent : IContent<TProperty>
        where TProperty : IProperty
        where TContentRedirect : IContentRedirect {

        /// <summary>
        /// Gets content by cache
        /// </summary>
        /// <param name="route"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        TContent? GetContentByRouteCache(string route, string? culture, bool preview);

        /// <summary>
        /// Gets content by routing
        /// </summary>
        /// <param name="route"></param>
        /// <param name="baseUrl"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        Task<TContent?> GetContentByRouting(string route, string baseUrl, string? culture);

        /// <summary>
        /// Gets a content redirect result
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        TContent? GetRedirect(IPublishedRequest request);

        /// <summary>
        /// Sets the baseUrl if none is set
        /// </summary>
        /// <param name="baseUrl"></param>
        /// <returns></returns>
        string SetBaseUrl(string baseUrl);
    }
}