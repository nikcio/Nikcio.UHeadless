using Nikcio.UHeadless.Base.Elements.Repositories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.Content.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Content.Repositories {
    /// <inheritdoc/>
    public class ContentRepository<TContent, TProperty> : CachedElementRepository<TContent, TProperty>, IContentRepository<TContent, TProperty>
        where TContent : IContent<TProperty>
        where TProperty : IProperty {

        /// <inheritdoc/>
        public ContentRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IContentFactory<TContent, TProperty> contentFactory) : base(publishedSnapshotAccessor, umbracoContextFactory, contentFactory) {
            umbracoContextFactory.EnsureUmbracoContext();
        }

        /// <inheritdoc/>
        public virtual TContent? GetContent(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture) {
            return base.GetElement(fetch, culture, publishedSnapshot => publishedSnapshot.Content);
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TContent?> GetContentList(Func<IPublishedContentCache?, IEnumerable<IPublishedContent>?> fetch, string? culture) {
            return base.GetElementList(fetch, culture, publishedSnapshot => publishedSnapshot.Content);
        }

        /// <inheritdoc/>
        public virtual TContent? GetConvertedContent(IPublishedContent? content, string? culture) {
            return base.GetConvertedElement(content, culture);
        }
    }
}
