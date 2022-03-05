using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <summary>
    /// A factory to create property values
    /// </summary>
    public interface IPropertyValueFactory
    {
        /// <summary>
        /// Get a property value
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        PropertyValueBaseGraphType? GetPropertyValue(CreatePropertyValue createPropertyValue);
    }
}