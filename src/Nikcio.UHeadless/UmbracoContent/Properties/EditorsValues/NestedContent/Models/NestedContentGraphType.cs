using HotChocolate;
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models
{
    [GraphQLDescription("Represents nested content.")]
    public class NestedContentGraphType<T> : PropertyValueBaseGraphType
        where T : ElementBaseGraphType
    {
        [GraphQLDescription("Gets the elements of a nested content.")]
        public virtual List<T> Elements { get; set; }

        public NestedContentGraphType(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
        {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>).ToList();
            Elements = elements.ToList()
                ?.Select(element =>
                {
                    var propertyTypeAssemblyQualifiedName = typeof(T).AssemblyQualifiedName;
                    var type = Type.GetType(propertyTypeAssemblyQualifiedName);
                    return dependencyReflectorFactory.GetReflectedType<T>(type, new object[] { new CreateElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
                }).ToList();
        }
    }
}
