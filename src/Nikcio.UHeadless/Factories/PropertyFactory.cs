using AutoMapper;
using Nikcio.UHeadless.Dtos.Content;
using Nikcio.UHeadless.Dtos.Propreties;
using Nikcio.UHeadless.Dtos.Propreties.PropertyValues;
using Nikcio.UHeadless.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories
{
    public class PropertyFactory : IPropertyFactory
    {
        private readonly IMapper mapper;

        public PropertyFactory(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public void AddProperty(PublishedContentGraphType mappedObject, IPublishedProperty property)
        {
            if(mappedObject.Properties == null)
            {
                mappedObject.Properties = new List<PublishedPropertyGraphType>();
            }
            mappedObject.Properties.Add(GetPropertyGraphType(property));
        }

        private PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property)
        {
            var propertyEditorAlias = property.PropertyType.DataType.EditorAlias;
            if (propertyEditorAlias == Constants.PropertyEditors.Aliases.NestedContent)
            {
                return null;
            }
            else if(propertyEditorAlias == Constants.PropertyEditors.Aliases.BlockList)
            {
                return new PublishedPropertyGraphType { Alias = property.Alias, Value = new PropertyValueBlocklistModelGraphType(property, mapper) };
            }
            else
            {
                return new PublishedPropertyGraphType { Alias = property.Alias, Value = new PropertyValueBasicGraphType { Value = property.GetValue() } };
            }
        }

        //private IPropertyValueBaseGraphType GetPropertyValue(IPublishedProperty property)
        //{
        //    var propertyType = property.GetType();
        //    if(propertyType == typeof(BlockListModel))
        //    {

        //    }
        //    else
        //    {
        //        return property.GetValue();
        //    }
        //    switch (property.GetType())
        //    {
        //        case typeof(BlockListModel):
        //            return property.GetValue();
        //        default:
        //            return null;
        //    }
        //}
    }
}
