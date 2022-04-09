using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Repositories
{
    /// <summary>
    /// A repository for getting properties
    /// </summary>
    public interface IPropertyRespository<T>
        where T : IProperty
    {
        /// <summary>
        /// Gets properties based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<T>? GetProperties(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture);

        /// <summary>
        /// Gets properties based on <see cref="IPublishedContent"/>
        /// </summary>
        /// <param name="content">The <see cref="IPublishedContent"/></param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<T> GetProperties(IPublishedContent content, string? culture);
    }
}