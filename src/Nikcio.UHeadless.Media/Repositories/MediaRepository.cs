using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Elements.Repositories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Media.Factories;
using Nikcio.UHeadless.Media.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Media.Repositories;

/// <inheritdoc/>
public class MediaRepository<TMedia, TProperty> : CachedElementRepository<TMedia, TProperty>, IMediaRepository<TMedia, TProperty>
    where TMedia : IMedia<TProperty>
    where TProperty : IProperty
{
    /// <inheritdoc/>
    public MediaRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IMediaFactory<TMedia, TProperty> mediaFactory, ILogger<MediaRepository<TMedia, TProperty>> logger) : base(publishedSnapshotAccessor, umbracoContextFactory, mediaFactory, logger)
    {
        umbracoContextFactory.EnsureUmbracoContext();
    }

    /// <inheritdoc/>
    public virtual TMedia? GetMedia(Func<IPublishedMediaCache?, IPublishedContent?> fetch)
    {
        return base.GetElement(fetch, null, null, null, publishedSnapshot => publishedSnapshot.Media);
    }

    /// <inheritdoc/>
    public virtual IEnumerable<TMedia?> GetMediaList(Func<IPublishedMediaCache?, IEnumerable<IPublishedContent>?> fetch)
    {
        return base.GetElementList(fetch, null, null, null, publishedSnapshot => publishedSnapshot.Media);
    }

    /// <inheritdoc/>
    public virtual TMedia? GetConvertedMedia(IPublishedContent media)
    {
        return base.GetConvertedElement(media, null, null, null);
    }
}
