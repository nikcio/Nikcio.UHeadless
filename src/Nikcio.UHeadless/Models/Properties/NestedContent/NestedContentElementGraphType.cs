using Nikcio.UHeadless.Commands.Elements;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Models.Properties.NestedContent
{
    public class NestedContentElementGraphType : ElementBaseGraphType
    {
        public List<PublishedPropertyGraphType> Properties { get; set; } = new List<PublishedPropertyGraphType>();

        public NestedContentElementGraphType(CreateElement createElement, IPropertyFactory propertyFactory) : base(createElement)
        {
            if (createElement.Element != null)
            {
                foreach (var property in createElement.Element.Properties)
                {
                    Properties.Add(propertyFactory.GetPropertyGraphType(property, createElement.Content, createElement.Culture));
                }
            }
        }
    }
}
