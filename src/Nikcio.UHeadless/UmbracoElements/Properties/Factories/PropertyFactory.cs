using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Factories
{
    /// <inheritdoc/>
    public class PropertyFactory<TProperty> : IPropertyFactory<TProperty>
        where TProperty : IProperty, new()
    {
        /// <summary>
        /// A factory for creating property values
        /// </summary>
        protected readonly IPropertyValueFactory propertyValueFactory;

        /// <inheritdoc/>
        public PropertyFactory(IPropertyValueFactory propertyValueFactory)
        {
            this.propertyValueFactory = propertyValueFactory;
        }

        /// <inheritdoc/>
        public virtual TProperty GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new CreatePropertyValue(publishedContent, property, culture ?? ""));
            return new TProperty { Alias = property.Alias, Value = propertyValue, EditorAlias = property.PropertyType.EditorAlias };
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty> CreateProperties(IPublishedContent publishedContent, string? culture)
        {
            return publishedContent.Properties.Select(IPublishedProperty => GetProperty(IPublishedProperty, publishedContent, culture));
        }

    }
}
