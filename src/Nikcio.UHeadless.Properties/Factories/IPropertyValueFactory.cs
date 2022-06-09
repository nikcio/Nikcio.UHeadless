using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;

namespace Nikcio.UHeadless.Properties.Factories {
    /// <summary>
    /// A factory to create property values
    /// </summary>
    public interface IPropertyValueFactory {
        /// <summary>
        /// Get a property value
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        PropertyValue? GetPropertyValue(CreatePropertyValue createPropertyValue);
    }
}