using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Base.Elements.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Base.Elements.Repositories;

/// <summary>
/// A repository for elements
/// </summary>
/// <typeparam name="TElement"></typeparam>
public abstract class CachedElementRepository<TElement> : ElementRepository<TElement>
    where TElement : IElement
{
    /// <summary>
    /// A published snapshot service
    /// </summary>
    protected readonly IPublishedSnapshotService publishedSnapshotService;

    /// <summary>
    /// A logger
    /// </summary>
    protected readonly ILogger logger;

    /// <inheritdoc/>
    protected CachedElementRepository(IUmbracoContextFactory umbracoContextFactory, IPublishedSnapshotService publishedSnapshotService, IElementFactory<TElement> elementFactory, ILogger logger) : base(umbracoContextFactory, elementFactory)
    {
        this.publishedSnapshotService = publishedSnapshotService;
        this.logger = logger;
    }

    /// <summary>
    /// Gets an element
    /// </summary>
    /// <param name="fetch"></param>
    /// <param name="culture"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <param name="cacheSelector"></param>
    /// <returns></returns>
    protected virtual TElement? GetElement<TPublishedCache>(Func<TPublishedCache?, IPublishedContent?> fetch, string? culture, string? segment, Fallback? fallback, Expression<Func<IPublishedSnapshot, IPublishedCache?>> cacheSelector)
        where TPublishedCache : IPublishedCache
    {
        var publishedCache = GetPublishedCache(cacheSelector);
        if (publishedCache is TPublishedCache typedPublishedCache)
        {
            return base.GetElement(fetch(typedPublishedCache), culture, segment, fallback);
        }
        return default;
    }

    /// <summary>
    /// Gets a list of elements
    /// </summary>
    /// <param name="fetch"></param>
    /// <param name="culture"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <param name="cacheSelector"></param>
    /// <returns></returns>
    protected virtual IEnumerable<TElement?> GetElementList<TPublishedCache>(Func<TPublishedCache?, IEnumerable<IPublishedContent>?> fetch, string? culture, string? segment, Fallback? fallback, Expression<Func<IPublishedSnapshot, IPublishedCache?>> cacheSelector)
        where TPublishedCache : IPublishedCache
    {
        var publishedCache = GetPublishedCache(cacheSelector);
        if (publishedCache is TPublishedCache typedPublishedCache)
        {
            return base.GetElementList(fetch(typedPublishedCache), culture, segment, fallback);
        }
        return Enumerable.Empty<TElement>();
    }

    /// <summary>
    /// Gets a publish cache
    /// </summary>
    /// <param name="cacheSelector"></param>
    /// <returns></returns>
    protected virtual IPublishedCache? GetPublishedCache(Expression<Func<IPublishedSnapshot, IPublishedCache?>> cacheSelector)
    {
        var publishedSnapshot = publishedSnapshotService.CreatePublishedSnapshot(null); // This ensures that we always get the latest snapshot
        var compiledCacheSelector = cacheSelector.Compile();
        return compiledCacheSelector(publishedSnapshot);
    }
}
