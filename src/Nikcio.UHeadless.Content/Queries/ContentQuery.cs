using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Enums;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Content.Router;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Content.Queries;

/// <summary>
/// The base implementation of the content queries
/// </summary>
/// <typeparam name="TContent"></typeparam>
/// <typeparam name="TProperty"></typeparam>
/// <typeparam name="TContentRedirect"></typeparam>
public class ContentQuery<TContent, TProperty, TContentRedirect>
    where TContent : IContent<TProperty>
    where TProperty : IProperty
    where TContentRedirect : IContentRedirect
{
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
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
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
                                              [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
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
                                            [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return contentRepository.GetContent(x => x?.GetById(preview, id), culture);
    }

    /// <summary>
    /// Gets a content item by an absolute route
    /// </summary>
    /// <param name="contentRouter"></param>
    /// <param name="route"></param>
    /// <param name="baseUrl"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <param name="routeMode"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets a content item by an absolute route.")]
    [UseFiltering]
    [UseSorting]
    public virtual async Task<TContent?> GetContentByAbsoluteRoute(
                                               [Service] IContentRouter<TContent, TProperty, TContentRedirect> contentRouter,
                                               [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route,
                                               [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "",
                                               [GraphQLDescription("The culture.")] string? culture = null,
                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
                                               [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing)
    {

        if (routeMode is RouteMode.Routing or RouteMode.RoutingOrCache)
        {
            baseUrl = contentRouter.SetBaseUrl(baseUrl);
        }

        return routeMode switch
        {
            RouteMode.Routing => await contentRouter.GetContentByRouting(route, baseUrl, culture),
            RouteMode.RoutingOrCache => await contentRouter.GetContentByRouting(route, baseUrl, culture) ?? contentRouter.GetContentByRouteCache(route, culture, preview),
            RouteMode.CacheOrRouting => contentRouter.GetContentByRouteCache(route, culture, preview) ?? await contentRouter.GetContentByRouting(route, baseUrl, culture),
            RouteMode.CacheOnly => contentRouter.GetContentByRouteCache(route, culture, preview),
            _ => await contentRouter.GetContentByRouting(route, baseUrl, culture),
        };
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
                                                           [GraphQLDescription("The culture.")] string? culture = null)
    {

        return contentRepository.GetContentList(x =>
        {
            var publishedContentType = x?.GetContentType(contentType);
            return publishedContentType != null ? x?.GetByContentType(publishedContentType) : default;
        }, culture);
    }

    /// <summary>
    /// Gets all the content items available
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all the content items available.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> GetContentAll([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return contentRepository.GetContentList(x =>
        {
            return x?.GetAtRoot(preview, culture).SelectMany(content => content.Descendants(culture))
                .Concat(x?.GetAtRoot(preview, culture) ?? Enumerable.Empty<IPublishedContent>());
        }, culture);
    }

    /// <summary>
    /// Gets descendants on a content item selected by guid
    /// </summary>
    /// <param name="id"></param>
    /// <param name="contentRepository"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets descendants on a content item selected by guid.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> GetContentDescendantsByGuid([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The id to fetch.")] Guid id,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return contentRepository.GetContentList(x =>
        {
            return x?.GetById(preview, id)?.Descendants(culture) ?? Enumerable.Empty<IPublishedContent>();
        }, culture);
    }

    /// <summary>
    /// Gets descendants on a content item selected by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="contentRepository"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets descendants on a content item selected by id.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> GetContentDescendantsById([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The id to fetch.")] int id,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return contentRepository.GetContentList(x =>
        {
            return x?.GetById(preview, id)?.Descendants(culture) ?? Enumerable.Empty<IPublishedContent>();
        }, culture);
    }

    /// <summary>
    /// Gets all descendants of content items with a specific content type (Missing preview)
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="contentType"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all descendants of content items with a specific content type.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> GetContentDescendantsByContentType([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The contentType to fetch.")] string contentType,
                                                           [GraphQLDescription("The culture.")] string? culture = null)
    {

        return contentRepository.GetContentList(x =>
        {
            var publishedContentType = x?.GetContentType(contentType);
            return publishedContentType != null ? x?.GetByContentType(publishedContentType).SelectMany(content => content.Descendants(culture)) : default;
        }, culture);
    }

    /// <summary>
    /// Gets content item descendants by an absolute route
    /// </summary>
    /// <param name="contentRouter"></param>
    /// <param name="route"></param>
    /// <param name="baseUrl"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <param name="routeMode"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets content item descendants by an absolute route.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual async Task<IEnumerable<TContent?>> GetContentDescendantsByAbsoluteRoute(
                                               [Service] IContentRouter<TContent, TProperty, TContentRedirect> contentRouter,
                                               [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route,
                                               [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "",
                                               [GraphQLDescription("The culture.")] string? culture = null,
                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
                                               [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing)
    {

        if (routeMode is RouteMode.Routing or RouteMode.RoutingOrCache)
        {
            baseUrl = contentRouter.SetBaseUrl(baseUrl);
        }

        return routeMode switch
        {
            RouteMode.Routing => await contentRouter.GetContentDescendantsByRouting(route, baseUrl, culture),
            RouteMode.RoutingOrCache => await contentRouter.GetContentDescendantsByRouting(route, baseUrl, culture) ?? contentRouter.GetContentDescendantsByRouteCache(route, culture, preview),
            RouteMode.CacheOrRouting => contentRouter.GetContentDescendantsByRouteCache(route, culture, preview) ?? await contentRouter.GetContentDescendantsByRouting(route, baseUrl, culture),
            RouteMode.CacheOnly => contentRouter.GetContentDescendantsByRouteCache(route, culture, preview),
            _ => await contentRouter.GetContentDescendantsByRouting(route, baseUrl, culture),
        };
    }

    /// <summary>
    /// Gets content items by tag
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="tagService"></param>
    /// <param name="tag"></param>
    /// <param name="tagGroup"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets content items by tag.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> GetContentByTag([Service] IContentRepository<TContent, TProperty> contentRepository,
                                              [Service] ITagService tagService,
                                              [GraphQLDescription("The tag to fetch.")] string tag,
                                              [GraphQLDescription("The tag group to fetch.")] string? tagGroup = null,
                                              [GraphQLDescription("The culture to fetch.")] string? culture = null)
    {
        return contentRepository.GetContentList(x =>
        {
            var taggedEntities = tagService.GetTaggedContentByTag(tag, tagGroup, culture);
            return taggedEntities.Select(entity => x?.GetById(entity.EntityId)).OfType<IPublishedContent>();
        }, culture);
    }
}