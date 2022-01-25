using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;

namespace Nikcio.UHeadless.Factories.Properties.PropertyValues
{
    public interface IPropertyValueFactory
    {
        PropertyValueBaseGraphType GetPropertyValue(CreatePropertyValue createPropertyValue);
    }
}