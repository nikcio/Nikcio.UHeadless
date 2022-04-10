using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <summary>
    /// A factory to create properties
    /// </summary>
    public interface IPropertyFactory<T>
        where T : IProperty
    {
        /// <summary>
        /// Gets a <see cref="BasicProperty"/> from a <see cref="IPublishedProperty"/>
        /// </summary>
        /// <param name="property">The <see cref="IPublishedProperty"/></param>
        /// <param name="publishedContent">The <see cref="IPublishedContent"/></param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        T GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture);

        IEnumerable<T> CreateProperties(IPublishedContent publishedContent, string? culture);
    }
}