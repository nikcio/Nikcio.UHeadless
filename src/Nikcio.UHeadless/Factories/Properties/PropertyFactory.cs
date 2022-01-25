using AutoMapper;
using Nikcio.UHeadless.Factories.Properties.PropertyValues;
using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories.Properties
{
    public class PropertyFactory : IPropertyFactory
    {
        private readonly IMapper mapper;
        private readonly IPropertyValueFactory propertyValueFactory;

        public PropertyFactory(IMapper mapper, IPropertyValueFactory propertyValueFactory)
        {
            this.mapper = mapper;
            this.propertyValueFactory = propertyValueFactory;
        }

        public void AddProperty(PublishedContentGraphType mappedObject, IPublishedProperty property)
        {
            if (mappedObject.Properties == null)
            {
                mappedObject.Properties = new List<PublishedPropertyGraphType>();
            }
            mappedObject.Properties.Add(GetPropertyGraphType(property));
        }

        private PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property)
        {
            var propertyValue = propertyValueFactory.GetPropertyValue(new Commands.Properties.CreatePropertyValue { Property = property, Mapper = mapper });
            return new PublishedPropertyGraphType { Alias = property.Alias, Value = propertyValue };

            //var propertyEditorAlias = property.PropertyType.DataType.EditorAlias;
            //if (propertyEditorAlias == Constants.PropertyEditors.Aliases.NestedContent)
            //{
            //    return null;
            //}
            //else if(propertyEditorAlias == Constants.PropertyEditors.Aliases.BlockList)
            //{
            //    return new PublishedPropertyGraphType { Alias = property.Alias, Value = new PropertyValueBlocklistModelGraphType(property, mapper) };
            //}
            //else
            //{
            //    return new PublishedPropertyGraphType { Alias = property.Alias, Value = new PropertyValueBasicGraphType { Value = property.GetValue() } };
            //}
        }
    }
}
