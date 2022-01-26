using AutoMapper;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Models.Properties
{
    public class NestedContentGraphType : PropertyValueBaseGraphType
    {
        public List<PublishedElementGraphType> Elements { get; set; }

        public NestedContentGraphType(CreatePropertyValue createPropertyValue, IMapper mapper, IPropertyFactory propertyFactory) : base(createPropertyValue)
        {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>).ToList();
            Elements = mapper.Map<IEnumerable<IPublishedElement>, IEnumerable<PublishedElementGraphType>>(elements).ToList();
            for(var i = 0; i < Elements.Count; i++)
            {
                foreach (var property in elements[i].Properties)
                {
                    propertyFactory.AddProperty(Elements[i], createPropertyValue.Content, property, createPropertyValue.Culture);
                }
            }
        }
    }
}
