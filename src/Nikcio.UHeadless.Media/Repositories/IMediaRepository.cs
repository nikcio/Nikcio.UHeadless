using Nikcio.UHeadless.Media.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Media.Repositories;

/// <summary>
/// A repository to get Media from Umbraco
/// </summary>
public interface IMediaRepository<TMedia>
    where TMedia : IMedia
{
    /// <summary>
    /// Gets the Media based on a fetch method
    /// </summary>
    /// <param name="fetch">The fetch method</param>
    /// <returns></returns>
    TMedia? GetMedia(Func<IPublishedMediaCache?, IPublishedContent?> fetch);

    /// <summary>
    /// Gets the Media based on IPublishedContent
    /// </summary>
    /// <param name="media">The IPublishedContent</param>
    /// <returns></returns>
    TMedia? GetMedia(IPublishedContent media);

    /// <summary>
    /// Gets a Media lsit based on a fetch method
    /// </summary>
    /// <param name="fetch">The fetch method</param>
    /// <returns></returns>
    IEnumerable<TMedia?> GetMediaList(Func<IPublishedMediaCache?, IEnumerable<IPublishedContent>?> fetch);

    /// <summary>
    /// Gets a Media lsit based on a IPubslishedContent collection
    /// </summary>
    /// <param name="mediaItems">The IPublishedcontent collection</param>
    /// <returns></returns>
    IEnumerable<TMedia?> GetMediaList(IEnumerable<IPublishedContent> mediaItems);

    /// <summary>
    /// Gets a <see cref="IPublishedContent"/> converted to T
    /// </summary>
    /// <param name="media">The published Media</param>
    /// <returns></returns>
    TMedia? GetConvertedMedia(IPublishedContent media);
}