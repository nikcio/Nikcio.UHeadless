using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Elements.Repositories;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Content.Repositories {
    /// <inheritdoc/>
    public class ContentRepository<TContent, TProperty> : ElementRepository<TContent, TProperty>, IContentRepository<TContent, TProperty>
        where TContent : IContent<TProperty>
        where TProperty : IProperty {

        /// <inheritdoc/>
        public ContentRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IContentFactory<TContent, TProperty> contentFactory) : base(publishedSnapshotAccessor, umbracoContextFactory, contentFactory) {
            umbracoContextFactory.EnsureUmbracoContext();
        }

        /// <inheritdoc/>
        public virtual TContent? GetContent(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture) {
            var publishedCache = base.GetPublishedCache(publishedCache => publishedCache.Content);
            if (publishedCache is not null and IPublishedContentCache publishedContentCache) {
                return base.GetElement(fetch(publishedContentCache), culture);
            }
            return default;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TContent?> GetContentList(Func<IPublishedContentCache?, IEnumerable<IPublishedContent>?> fetch, string? culture) {
            var publishedCache = base.GetPublishedCache(publishedCache => publishedCache.Content);
            if (publishedCache is not null and IPublishedContentCache publishedContentCache) {
                return base.GetElementList(fetch(publishedContentCache), culture);
            }
            return Enumerable.Empty<TContent>();
        }

        /// <inheritdoc/>
        public virtual TContent? GetConvertedContent(IPublishedContent? content, string? culture) {
            return base.GetConvertedElement(content, culture);
        }
    }
}
