using Nikcio.UHeadless.Base.Properties.Bases.Models;
using Nikcio.UHeadless.Base.Properties.Commands;

namespace Nikcio.UHeadless.Base.Properties.Factories {
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