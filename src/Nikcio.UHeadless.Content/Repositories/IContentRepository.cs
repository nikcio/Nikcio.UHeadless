using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Content.Repositories {
    /// <summary>
    /// A repository to get content from Umbraco
    /// </summary>
    public interface IContentRepository<TContent, TProperty>
        where TContent : IContent<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Gets the content based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        TContent? GetContent(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture);

        /// <summary>
        /// Gets a content lsit based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<TContent?> GetContentList(Func<IPublishedContentCache?, IEnumerable<IPublishedContent>?> fetch, string? culture);

        /// <summary>
        /// Gets a <see cref="IPublishedContent"/> converted to T
        /// </summary>
        /// <param name="content">The published content</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        TContent? GetConvertedContent(IPublishedContent? content, string? culture);
    }
}