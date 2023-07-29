using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Elements.Repositories;
using Nikcio.UHeadless.Media.Factories;
using Nikcio.UHeadless.Media.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Media.Repositories;

/// <inheritdoc/>
public class MediaRepository<TMedia> : CachedElementRepository<TMedia>, IMediaRepository<TMedia>
    where TMedia : IMedia
{
    /// <inheritdoc/>
    public MediaRepository(IUmbracoContextFactory umbracoContextFactory, IPublishedSnapshotService publishedSnapshotService, IMediaFactory<TMedia> mediaFactory, ILogger<MediaRepository<TMedia>> logger) : base(umbracoContextFactory, publishedSnapshotService, mediaFactory, logger)
    {
    }

    /// <inheritdoc/>
    public virtual TMedia? GetMedia(Func<IPublishedMediaCache?, IPublishedContent?> fetch)
    {
        return base.GetElement(fetch, null, null, null, publishedSnapshot => publishedSnapshot.Media);
    }

    /// <inheritdoc/>
    public virtual TMedia? GetMedia(IPublishedContent media)
    {
        return base.GetElement(media, null, null, null);
    }

    /// <inheritdoc/>
    public virtual IEnumerable<TMedia?> GetMediaList(Func<IPublishedMediaCache?, IEnumerable<IPublishedContent>?> fetch)
    {
        return base.GetElementList(fetch, null, null, null, publishedSnapshot => publishedSnapshot.Media);
    }

    /// <inheritdoc/>
    public virtual IEnumerable<TMedia?> GetMediaList(IEnumerable<IPublishedContent> mediaItems)
    {
        return base.GetElementList(mediaItems, null, null, null);
    }

    /// <inheritdoc/>
    public virtual TMedia? GetConvertedMedia(IPublishedContent media)
    {
        return base.GetConvertedElement(media, null, null, null);
    }
}
