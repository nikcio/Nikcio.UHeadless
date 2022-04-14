using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Factories
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
        PropertyValue? GetPropertyValue(CreatePropertyValue createPropertyValue);
    }
}