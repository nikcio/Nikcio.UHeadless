using System.Linq.Expressions;
using Nikcio.UHeadless.Elements.Factories;
using Nikcio.UHeadless.Elements.Models;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Elements.Repositories {
    /// <summary>
    /// A repository for elements
    /// </summary>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class ElementRepository<TElement, TProperty>
        where TElement : IElement<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// An accessor to the published shapshot
        /// </summary>
        protected readonly IPublishedSnapshotAccessor publishedSnapshotAccessor;

        /// <summary>
        /// A factory for creating elements
        /// </summary>
        protected readonly IElementFactory<TElement, TProperty> elementFactory;

        /// <inheritdoc/>
        protected ElementRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IElementFactory<TElement, TProperty> elementFactory) {
            umbracoContextFactory.EnsureUmbracoContext();
            this.publishedSnapshotAccessor = publishedSnapshotAccessor;
            this.elementFactory = elementFactory;
        }

        /// <summary>
        /// Gets an element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual TElement? GetElement(IPublishedContent? element, string? culture) {
            if (element == null) {
                return default;
            }

            return GetConvertedElement(element, culture);
        }

        /// <summary>
        /// Gets a list of elements
        /// </summary>
        /// <param name="elements"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual IEnumerable<TElement?> GetElementList(IEnumerable<IPublishedContent>? elements, string? culture) {
            if (elements == null) {
                return Enumerable.Empty<TElement>();
            }

            return elements.Select(element => GetConvertedElement(element, culture));
        }

        /// <summary>
        /// Gets a publish cache
        /// </summary>
        /// <param name="cacheSelector"></param>
        /// <returns></returns>
        protected virtual IPublishedCache? GetPublishedCache(Expression<Func<IPublishedSnapshot, IPublishedCache>> cacheSelector) {
            if (publishedSnapshotAccessor.TryGetPublishedSnapshot(out var publishedSnapshot)) {
                var compiledCacheSelector = cacheSelector.Compile();
                return compiledCacheSelector(publishedSnapshot);
            }
            return null;
        }

        /// <summary>
        /// Get the converted element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected virtual TElement? GetConvertedElement(IPublishedContent? element, string? culture) {
            return elementFactory.CreateElement(element, culture);
        }
    }
}
