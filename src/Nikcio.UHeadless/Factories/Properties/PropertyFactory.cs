using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties.PropertyValues;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories.Properties
{
    public class PropertyFactory : IPropertyFactory
    {
        private readonly IPropertyValueFactory propertyValueFactory;

        public PropertyFactory(IPropertyValueFactory propertyValueFactory)
        {
            this.propertyValueFactory = propertyValueFactory;
        }

        public PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new CreatePropertyValue(publishedContent, property, culture));
            return new PublishedPropertyGraphType { Alias = property.Alias, Value = propertyValue, EditorAlias = property.PropertyType.EditorAlias };
        }
    }
}
