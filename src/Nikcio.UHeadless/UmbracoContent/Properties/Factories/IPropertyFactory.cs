using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <summary>
    /// A factory to create properties
    /// </summary>
    public interface IPropertyFactory
    {
        /// <summary>
        /// Gets a <see cref="PublishedPropertyGraphType"/> from a <see cref="IPublishedProperty"/>
        /// </summary>
        /// <param name="property">The <see cref="IPublishedProperty"/></param>
        /// <param name="publishedContent">The <see cref="IPublishedContent"/></param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture);
    }
}