using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    public interface IPropertyValueFactory
    {
        PropertyValueBaseGraphType GetPropertyValue(CreatePropertyValue createPropertyValue);
    }
}