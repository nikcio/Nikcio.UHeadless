using AutoMapper;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties.PropertyValues;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System.Collections.Generic;
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

        public void AddProperty(PublishedContentGraphType mappedObject, IPublishedContent publishedContent, IPublishedProperty property, string culture)
        {
            AddProperty(mappedObject as PublishedElementGraphType, publishedContent, property, culture);
        }

        public void AddProperty(PublishedElementGraphType mappedObject, IPublishedContent publishedContent, IPublishedProperty property, string culture)
        {
            if (mappedObject.Properties == null)
            {
                mappedObject.Properties = new List<PublishedPropertyGraphType>();
            }
            mappedObject.Properties.Add(GetPropertyGraphType(property, publishedContent, culture));
        }

        private PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new CreatePropertyValue(publishedContent, property, culture));
            return new PublishedPropertyGraphType { Alias = property.Alias, Value = propertyValue };
        }
    }
}
