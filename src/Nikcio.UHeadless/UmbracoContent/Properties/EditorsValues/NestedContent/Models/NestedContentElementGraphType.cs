using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models
{
    [GraphQLDescription("Represents nested content.")]
    public class NestedContentElementGraphType<TPropertyGraphType> : ElementBaseGraphType
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        [GraphQLDescription("Gets the properties of the nested content.")]
        public List<TPropertyGraphType> Properties { get; set; } = new List<TPropertyGraphType>();

        public NestedContentElementGraphType(CreateElement createElement, IPropertyFactory<TPropertyGraphType> propertyFactory) : base(createElement)
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
