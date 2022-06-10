using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Enums;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Routing;

namespace Nikcio.UHeadless.Content.Queries {
    /// <summary>
    /// The base implementation of the content queries
    /// </summary>
    /// <typeparam name="TContent"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TContentRedirect"></typeparam>
    public class ContentQuery<TContent, TProperty, TContentRedirect>
        where TContent : IContent<TProperty>
        where TProperty : IProperty
        where TContentRedirect : IContentRedirect {
        /// <summary>
        /// Gets all the content items at root level
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets all the content items at root level.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TContent?> GetContentAtRoot([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                               [GraphQLDescription("The culture.")] string? culture = null,
                                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return contentRepository.GetContentList(x => x?.GetAtRoot(preview, culture), culture);
        }

        /// <summary>
        /// Gets a content item by guid
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a content item by guid.")]
        [UseFiltering]
        [UseSorting]
        public virtual TContent? GetContentByGuid([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                  [GraphQLDescription("The id to fetch.")] Guid id,
                                                  [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                  [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return contentRepository.GetContent(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Gets a content item by id
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a content item by id.")]
        [UseFiltering]
        [UseSorting]
        public virtual TContent? GetContentById([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                [GraphQLDescription("The id to fetch.")] int id,
                                                [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return contentRepository.GetContent(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Gets a content item by route
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="route"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [Obsolete($"This doesn't handle redirects created by Umbraco. Use {nameof(GetContentByAbsoluteRoute)} instead")]
        [GraphQLDescription($"Gets a content item by route. [OBSOLETE use {nameof(GetContentByAbsoluteRoute)} instead]")]
        [UseFiltering]
        [UseSorting]
        public virtual TContent? GetContentByRoute([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                   [GraphQLDescription("The route to fetch.")] string route,
                                                   [GraphQLDescription("The culture.")] string? culture = null,
                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return contentRepository.GetContent(x => x?.GetByRoute(preview, route, culture: culture), culture);
        }

        /// <summary>
        /// Gets a content item by an absolute route
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="contentRedirectRepository"></param>
        /// <param name="httpContextAccessor"></param>
        /// <param name="publishedRouter"></param>
        /// <param name="route"></param>
        /// <param name="baseUrl"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <param name="routeMode"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a content item by an absolute route.")]
        [UseFiltering]
        [UseSorting]
        public virtual async Task<TContent?> GetContentByAbsoluteRoute([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                   [Service] IContentRedirectRepository<TContentRedirect> contentRedirectRepository,
                                                   [Service] IPublishedRouter publishedRouter,
                                                   [Service] IHttpContextAccessor httpContextAccessor,
                                                   [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route,
                                                   [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "",
                                                   [GraphQLDescription("The culture.")] string? culture = null,
                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
                                                   [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing) {

            return routeMode switch {
                RouteMode.Routing => await GetContentByRouting(),
                RouteMode.RoutingOrCache => await GetContentByRouting() ?? GetContentByRouteCache(),
                RouteMode.CacheOrRouting => GetContentByRouteCache() ?? await GetContentByRouting(),
                RouteMode.CacheOnly => GetContentByRouteCache(),
                _ => await GetContentByRouting(),
            };

            TContent? GetContentByRouteCache() {
                return contentRepository.GetContent(x => x?.GetByRoute(preview, route, culture: culture), culture);
            }

            async Task<TContent?> GetContentByRouting() {
                if (httpContextAccessor == null || httpContextAccessor.HttpContext == null) {
                    throw new NullReferenceException("HttpContext could not be found");
                }

                if (string.IsNullOrWhiteSpace(baseUrl)) {
                    baseUrl = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host.Host}";

                    if (httpContextAccessor.HttpContext.Request.Host.Port != 80 && httpContextAccessor.HttpContext.Request.Host.Port != 443) {
                        baseUrl += $":{httpContextAccessor.HttpContext.Request.Host.Port}";
                    }
                }

                var builder = await publishedRouter.CreateRequestAsync(new Uri($"{baseUrl}{route}"));
                var request = await publishedRouter.RouteRequestAsync(builder, new RouteRequestOptions(RouteDirection.Inbound));

                return request.GetRouteResult() switch {
                    UmbracoRouteResult.Redirect => GetRedirect(contentRedirectRepository, request, contentRepository),
                    UmbracoRouteResult.NotFound => default,
                    UmbracoRouteResult.Success => request.PublishedContent != null ? contentRepository.GetConvertedContent(request.PublishedContent, culture) : default,
                    _ => default,
                };
            }

            static TContent? GetRedirect(IContentRedirectRepository<TContentRedirect> contentRedirectRepository, IPublishedRequest request, IContentRepository<TContent, TProperty> contentRepository) {
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
        }

        /// <summary>
        /// Gets all the content items by content type (Missing preview)
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="contentType"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets all the content items by content type.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TContent?> GetContentByContentType([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                               [GraphQLDescription("The contentType to fetch.")] string contentType,
                                                               [GraphQLDescription("The culture.")] string? culture = null) {

            return contentRepository.GetContentList(x => {
                var publishedContentType = x?.GetContentType(contentType);
                return publishedContentType != null ? x?.GetByContentType(publishedContentType) : default;
            }, culture);
        }
    }
}