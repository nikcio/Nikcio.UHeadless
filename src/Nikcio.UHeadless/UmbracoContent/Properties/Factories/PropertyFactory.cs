using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Fallback.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    /// <inheritdoc/>
    public class PropertyFactory<T> : IPropertyFactory<T>
        where T : IProperty, new()
    {
        private readonly IPropertyValueFactory propertyValueFactory;

        /// <inheritdoc/>
        public PropertyFactory(IPropertyValueFactory propertyValueFactory)
        {
            this.propertyValueFactory = propertyValueFactory;
        }

        /// <inheritdoc/>
        public virtual T GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new CreatePropertyValue(publishedContent, property, culture ?? ""));
            return new T { Alias = property.Alias, Value = propertyValue, EditorAlias = property.PropertyType.EditorAlias };
        }

        public virtual IEnumerable<T> CreateProperties(IPublishedContent publishedContent, string? culture)
        {
            return publishedContent.Properties.Select(IPublishedProperty => GetProperty(IPublishedProperty, publishedContent, culture));
        }

    }
}
