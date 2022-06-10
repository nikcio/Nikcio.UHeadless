using Nikcio.UHeadless.Elements.Repositories;
using Nikcio.UHeadless.Media.Factories;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Media.Repositories {
    /// <inheritdoc/>
    public class MediaRepository<TMedia, TProperty> : ElementRepository<TMedia, TProperty>, IMediaRepository<TMedia, TProperty>
        where TMedia : IMedia<TProperty>
        where TProperty : IProperty {

        /// <inheritdoc/>
        public MediaRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IMediaFactory<TMedia, TProperty> mediaFactory) : base(publishedSnapshotAccessor, umbracoContextFactory, mediaFactory) {
            umbracoContextFactory.EnsureUmbracoContext();
        }

        /// <inheritdoc/>
        public virtual TMedia? GetMedia(Func<IPublishedMediaCache?, IPublishedContent?> fetch, string? culture) {
            var publishedCache = base.GetPublishedCache(publishedCache => publishedCache.Media);
            if (publishedCache is not null and IPublishedMediaCache publishedMediaCache) {
                return base.GetElement(fetch(publishedMediaCache), culture);
            }
            return default;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TMedia?> GetMediaList(Func<IPublishedMediaCache?, IEnumerable<IPublishedContent>?> fetch, string? culture) {
            var publishedCache = base.GetPublishedCache(publishedCache => publishedCache.Media);
            if (publishedCache is not null and IPublishedMediaCache publishedMediaCache) {
                return base.GetElementList(fetch(publishedMediaCache), culture);
            }
            return Enumerable.Empty<TMedia>();
        }

        /// <inheritdoc/>
        public virtual TMedia? GetConvertedMedia(IPublishedContent media, string? culture) {
            return base.GetConvertedElement(media, culture);
        }
    }
}
