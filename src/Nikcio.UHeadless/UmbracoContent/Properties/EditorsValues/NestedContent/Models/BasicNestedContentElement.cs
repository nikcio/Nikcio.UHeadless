using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models
{
    /// <summary>
    /// Represents nested content
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents nested content.")]
    public class BasicNestedContentElement<TProperty> : NestedContentElement
        where TProperty : IProperty
    {
        /// <summary>
        /// Gets the properties of the nested content
        /// </summary>
        [GraphQLDescription("Gets the properties of the nested content.")]
        public virtual List<TProperty> Properties { get; set; } = new List<TProperty>();

        /// <inheritdoc/>
        public BasicNestedContentElement(CreateNestedContentElement createElement, IPropertyFactory<TProperty> propertyFactory) : base(createElement)
        {
            if (createElement.Element != null)
            {
                foreach (var property in createElement.Element.Properties)
                {
                    Properties.Add(propertyFactory.GetProperty(property, createElement.Content, createElement.Culture));
                }
            }
        }
    }
}
