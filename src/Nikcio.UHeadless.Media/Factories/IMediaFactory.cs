using Nikcio.UHeadless.Media.Models;

namespace Nikcio.UHeadless.Media.Factories {
    /// <summary>
    /// A factory for creating media
    /// </summary>
    /// <typeparam name="TMedia"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public interface IMediaFactory<TMedia, TProperty>
        where TMedia : IMedia<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Creates media
        /// </summary>
        /// <param name="media"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        TMedia? CreateMedia(IPublishedContent media, string? culture);
    }
}