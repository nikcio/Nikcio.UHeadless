using Nikcio.UHeadless.Content.Models;

namespace Nikcio.UHeadless.Content.Factories {
    /// <summary>
    /// A factory for creating content
    /// </summary>
    /// <typeparam name="TContent"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public interface IContentFactory<TContent, TProperty>
            where TContent : IContent<TProperty>
            where TProperty : IProperty {
        /// <summary>
        /// Creates a content
        /// </summary>
        /// <param name="content"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        TContent? CreateContent(IPublishedContent? content, string? culture);
    }
}
