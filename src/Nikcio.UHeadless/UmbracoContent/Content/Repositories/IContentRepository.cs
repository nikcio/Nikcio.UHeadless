using Nikcio.UHeadless.UmbracoContent.Content.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.UmbracoContent.Content.Repositories
{
    /// <summary>
    /// A repository to get content from Umbraco
    /// </summary>
    public interface IContentRepository
    {
        /// <summary>
        /// Gets the content based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IContentGraphType GetContent(Func<IPublishedContentCache, IPublishedContent> fetch, string culture);
        
        /// <summary>
        /// Gets a content lsit based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<IContentGraphType> GetContentList(Func<IPublishedContentCache, IEnumerable<IPublishedContent>> fetch, string culture);

        /// <summary>
        /// Gets a <see cref="IPublishedContent"/> converted to a <see cref="IContentGraphType"/>
        /// </summary>
        /// <param name="content">The published content</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IContentGraphType GetConvertedContent(IPublishedContent content, string culture);
    }
}