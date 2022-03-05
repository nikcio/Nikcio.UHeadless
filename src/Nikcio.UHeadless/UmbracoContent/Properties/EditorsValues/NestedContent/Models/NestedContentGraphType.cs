using HotChocolate;
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Commands;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models
{
    /// <summary>
    /// Represents nested content
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [GraphQLDescription("Represents nested content.")]
    public class NestedContentGraphType<T> : PropertyValueBaseGraphType
        where T : ElementBaseGraphType
    {
        /// <summary>
        /// Gets the elements of a nested content
        /// </summary>
        [GraphQLDescription("Gets the elements of a nested content.")]
        public virtual List<T>? Elements { get; set; }

        /// <inheritdoc/>
        public NestedContentGraphType(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
        {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>)?.ToList();
            if (elements == null)
            {
                return;
            }

            Elements = elements.Select(element =>
                {
                    var type = typeof(T);
                    return dependencyReflectorFactory.GetReflectedType<T>(type, new object[] { new CreateElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
                }).OfType<T>().ToList();
        }
    }
}
