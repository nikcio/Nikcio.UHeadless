using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models
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
