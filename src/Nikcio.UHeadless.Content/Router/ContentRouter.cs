using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Properties.Models;
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
        protected readonly IContentRedirectRepository<TContentRedirect> ContentRedirectRepository;

        /// <summary>
        /// A content repository
        /// </summary>
        protected readonly IContentRepository<TContent, TProperty> ContentRepository;

        /// <summary>
        /// The published router
        /// </summary>
        protected readonly IPublishedRouter PublishedRouter;

        /// <summary>
        /// The httpcontext accessor
        /// </summary>
        protected readonly IHttpContextAccessor HttpContextAccessor;

        /// <inheritdoc/>
        public ContentRouter(IContentRedirectRepository<TContentRedirect> contentRedirectRepository, IContentRepository<TContent, TProperty> contentRepository, IPublishedRouter publishedRouter, IHttpContextAccessor httpContextAccessor) {
            ContentRedirectRepository = contentRedirectRepository;
            ContentRepository = contentRepository;
            PublishedRouter = publishedRouter;
            HttpContextAccessor = httpContextAccessor;
        }

        /// <inheritdoc/>
        public virtual TContent? GetRedirect(IPublishedRequest request) {
            if (request.RedirectUrl == null) {
                return default;
            }
            var redirect = ContentRedirectRepository.GetContentRedirect(new CreateContentRedirect(request.RedirectUrl, request.IsRedirectPermanent()));
            var emptyContent = ContentRepository.GetConvertedContent(null, null);

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
            var builder = await PublishedRouter.CreateRequestAsync(new Uri($"{baseUrl}{route}"));
            var request = await PublishedRouter.RouteRequestAsync(builder, new RouteRequestOptions(RouteDirection.Inbound));

            return request.GetRouteResult() switch {
                UmbracoRouteResult.Redirect => GetRedirect(request),
                UmbracoRouteResult.NotFound => default,
                UmbracoRouteResult.Success => request.PublishedContent != null ? ContentRepository.GetConvertedContent(request.PublishedContent, culture) : default,
                _ => default,
            };
        }

        /// <inheritdoc/>
        public virtual string SetBaseUrl(string baseUrl) {
            if (string.IsNullOrWhiteSpace(baseUrl)) {
                if (HttpContextAccessor == null || HttpContextAccessor.HttpContext == null) {
                    throw new NullReferenceException("HttpContext could not be found");
                }

                baseUrl = $"{HttpContextAccessor.HttpContext.Request.Scheme}://{HttpContextAccessor.HttpContext.Request.Host.Host}";

                if (HttpContextAccessor.HttpContext.Request.Host.Port is not 80 and not 443) {
                    baseUrl += $":{HttpContextAccessor.HttpContext.Request.Host.Port}";
                }
            }

            return baseUrl;
        }

        /// <inheritdoc/>
        public virtual TContent? GetContentByRouteCache(string route, string? culture, bool preview) {
            return ContentRepository.GetContent(x => x?.GetByRoute(preview, route, culture: culture), culture);
        }

    }
}
