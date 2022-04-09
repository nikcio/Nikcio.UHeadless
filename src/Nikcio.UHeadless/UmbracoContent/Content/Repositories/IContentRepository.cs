using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.UmbracoContent.Content.Repositories
{
    /// <summary>
    /// A repository to get content from Umbraco
    /// </summary>
    public interface IContentRepository<T, TProperty>
        where T : IContent<TProperty>, new()
        where TProperty : IProperty
    {
        /// <summary>
        /// Gets the content based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        T? GetContent(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture);

        /// <summary>
        /// Gets a content lsit based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<T> GetContentList(Func<IPublishedContentCache?, IEnumerable<IPublishedContent>?> fetch, string? culture);

        /// <summary>
        /// Gets a <see cref="IPublishedContent"/> converted to T
        /// </summary>
        /// <param name="content">The published content</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        T GetConvertedContent(IPublishedContent content, string culture);
    }
}