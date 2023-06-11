using System.Linq.Expressions;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Base.Elements.Repositories;

/// <summary>
/// A repository for elements
/// </summary>
/// <typeparam name="TElement"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public abstract class CachedElementRepository<TElement, TProperty> : ElementRepository<TElement, TProperty>
    where TElement : IElement
    where TProperty : IProperty
{
    /// <summary>
    /// An accessor to the published shapshot
    /// </summary>
    protected readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

    /// <summary>
    /// A logger
    /// </summary>
    protected readonly ILogger logger;

    /// <inheritdoc/>
    protected CachedElementRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IElementFactory<TElement, TProperty> elementFactory, ILogger logger) : base(umbracoContextFactory, elementFactory)
    {
        umbracoContextFactory.EnsureUmbracoContext();
        this.publishedSnapshotAccessor = publishedSnapshotAccessor;
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
        if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot))
        {
            if (publishedSnapshot is null)
            {
                logger.LogError("Unable to get publishedSnapShot");
                return null;
            }
            var compiledCacheSelector = cacheSelector.Compile();
            return compiledCacheSelector(publishedSnapshot);
        }
        logger.LogError("Unable to get publishedSnapShot");
        return null;
    }
}
