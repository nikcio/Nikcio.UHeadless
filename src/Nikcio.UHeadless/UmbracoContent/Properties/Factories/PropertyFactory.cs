using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <inheritdoc/>
    public class PropertyFactory<T> : IPropertyFactory<T>
        where T : IPropertyGraphTypeBase, new()
    {
        private readonly IPropertyValueFactory propertyValueFactory;

        public PropertyFactory(IPropertyValueFactory propertyValueFactory)
        {
            this.propertyValueFactory = propertyValueFactory;
        }

        /// <inheritdoc/>
        public virtual T GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new CreatePropertyValue(publishedContent, property, culture));
            return new T { Alias = property.Alias, Value = propertyValue, EditorAlias = property.PropertyType.EditorAlias };
        }

    }
}
