using Nikcio.UHeadless.Commands.BlockLists;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.UHeadless.Models.Properties.NestedContent
{
    public class NestedContentElementGraphType : ElementBaseGraphType
    {
        public List<PublishedPropertyGraphType> Properties { get; set; } = new List<PublishedPropertyGraphType>();

        public NestedContentElementGraphType(CreateElement createElement, IPropertyFactory propertyFactory) : base(createElement)
        {
            if(createElement.Element != null)
            {
                foreach (var property in createElement.Element.Properties)
                {
                    Properties.Add(propertyFactory.GetPropertyGraphType(property, createElement.Content, createElement.Culture));
                }
            }
        }
    }
}
