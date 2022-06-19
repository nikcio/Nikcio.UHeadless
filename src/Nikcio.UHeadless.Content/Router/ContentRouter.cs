using Microsoft.AspNetCore.Http;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;
using Umbraco.Cms.Core.Routing;

namespace Nikcio.UHeadless.Content.Router {
    /// <inheritdoc/>
    public class ContentRouter<TContent, TProperty, TContentRedirect> : IContentRouter<TContent, TProperty, TContentRedirect>
        where TContent : IContent<TProperty>
        where TProperty : IProperty
        where TContentRedirect : IContentRedirect {

        /// <summary>
        /// A content redirect repository
        /// </summary>
        protected readonly IContentRedirectRepository<TContentRedirect> contentRedirectRepository;

        /// <summary>
        /// A content repository
        /// </summary>
        protected readonly IContentRepository<TContent, TProperty> contentRepository;

        /// <summary>
        /// The published router
        /// </summary>
        protected readonly IPublishedRouter publishedRouter;

        /// <summary>
        /// The httpcontext accessor
        /// </summary>
        protected readonly IHttpContextAccessor httpContextAccessor;

        /// <inheritdoc/>
        public ContentRouter(IContentRedirectRepository<TContentRedirect> contentRedirectRepository, IContentRepository<TContent, TProperty> contentRepository, IPublishedRouter publishedRouter, IHttpContextAccessor httpContextAccessor) {
            this.contentRedirectRepository = contentRedirectRepository;
            this.contentRepository = contentRepository;
            this.publishedRouter = publishedRouter;
            this.httpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc/>
        public virtual TContent? GetRedirect(IPublishedRequest request) {
            if (request.RedirectUrl == null) {
                return default;
            }
            var redirect = contentRedirectRepository.GetContentRedirect(new CreateContentRedirect(request.RedirectUrl, request.IsRedirectPermanent()));
            var emptyContent = contentRepository.GetConvertedContent(null, null);

            if (emptyContent == null) {
                return default;
            } else {
                var redirectProperty = emptyContent.GetType().GetProperty(nameof(IContent<TProperty>.Redirect));
                if (redirectProperty == null) {
                    return default;
                }
                redirectProperty.SetValue(emptyContent, redirect);
                return emptyContent;
            }
        }

        /// <inheritdoc/>
        public virtual async Task<TContent?> GetContentByRouting(string route, string baseUrl, string? culture) {
            var builder = await publishedRouter.CreateRequestAsync(new Uri($"{baseUrl}{route}"));
            var request = await publishedRouter.RouteRequestAsync(builder, new RouteRequestOptions(RouteDirection.Inbound));

            return request.GetRouteResult() switch {
                UmbracoRouteResult.Redirect => GetRedirect(request),
                UmbracoRouteResult.NotFound => default,
                UmbracoRouteResult.Success => request.PublishedContent != null ? contentRepository.GetConvertedContent(request.PublishedContent, culture) : default,
                _ => default,
            };
        }

        /// <inheritdoc/>
        public virtual string SetBaseUrl(string baseUrl) {
            if (string.IsNullOrWhiteSpace(baseUrl)) {
                if (httpContextAccessor == null || httpContextAccessor.HttpContext == null) {
                    throw new HttpRequestException("HttpContext could not be found");
                }

                baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host.Host}";

                if (httpContextAccessor.HttpContext.Request.Host.Port is not 80 and not 443) {
                    baseUrl += $":{httpContextAccessor.HttpContext.Request.Host.Port}";
                }
            }

            return baseUrl;
        }

        /// <inheritdoc/>
        public virtual TContent? GetContentByRouteCache(string route, string? culture, bool preview) {
            return contentRepository.GetContent(x => x?.GetByRoute(preview, route, culture: culture), culture);
        }

    }
}
