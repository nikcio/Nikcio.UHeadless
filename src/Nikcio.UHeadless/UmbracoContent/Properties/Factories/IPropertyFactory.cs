using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <summary>
    /// A factory to create properties
    /// </summary>
    public interface IPropertyFactory<T>
        where T : IPropertyGraphTypeBase
    {
        /// <summary>
        /// Gets a <see cref="PropertyGraphType"/> from a <see cref="IPublishedProperty"/>
        /// </summary>
        /// <param name="property">The <see cref="IPublishedProperty"/></param>
        /// <param name="publishedContent">The <see cref="IPublishedContent"/></param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        T GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string? culture);
    }
}