using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Properties.Factories {
    /// <summary>
    /// A factory to create properties
    /// </summary>
    public interface IPropertyFactory<out TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Gets a <see cref="BasicProperty"/> from a <see cref="IPublishedProperty"/>
        /// </summary>
        /// <param name="property">The <see cref="IPublishedProperty"/></param>
        /// <param name="publishedContent">The <see cref="IPublishedContent"/></param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        TProperty? GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture);

        /// <summary>
        /// Creates properties based on published content
        /// </summary>
        /// <param name="publishedContent"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        IEnumerable<TProperty?> CreateProperties(IPublishedContent publishedContent, string? culture);
    }
}