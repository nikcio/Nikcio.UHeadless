using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <inheritdoc/>
    public class PropertyFactory : IPropertyFactory
    {
        private readonly IPropertyValueFactory propertyValueFactory;

        public PropertyFactory(IPropertyValueFactory propertyValueFactory)
        {
            this.propertyValueFactory = propertyValueFactory;
        }

        /// <inheritdoc/>
        public PropertyGraphType GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new CreatePropertyValue(publishedContent, property, culture));
            return new PropertyGraphType { Alias = property.Alias, Value = propertyValue, EditorAlias = property.PropertyType.EditorAlias };
        }

    }
}
