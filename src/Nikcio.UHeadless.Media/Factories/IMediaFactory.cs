using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Media.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Media.Factories;

/// <summary>
/// A factory for creating media
/// </summary>
/// <typeparam name="TMedia"></typeparam>
public interface IMediaFactory<TMedia> : IElementFactory<TMedia>
    where TMedia : IMedia
{
    /// <summary>
    /// Creates media
    /// </summary>
    /// <param name="media"></param>
    /// <returns></returns>
    TMedia? CreateMedia(IPublishedContent media);
}