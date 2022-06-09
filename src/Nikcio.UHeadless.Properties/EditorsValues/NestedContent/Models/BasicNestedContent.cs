using HotChocolate;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.NestedContent.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Properties.EditorsValues.NestedContent.Models {
    /// <summary>
    /// Represents nested content
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [GraphQLDescription("Represents nested content.")]
    public class BasicNestedContent<T> : PropertyValue
        where T : NestedContentElement {
        /// <summary>
        /// Gets the elements of a nested content
        /// </summary>
        [GraphQLDescription("Gets the elements of a nested content.")]
        public virtual List<T>? Elements { get; set; }

        /// <inheritdoc/>
        public BasicNestedContent(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>)?.ToList();
            if (elements == null) {
                return;
            }

            Elements = elements.Select(element => {
                var type = typeof(T);
                return dependencyReflectorFactory.GetReflectedType<T>(type, new object[] { new CreateNestedContentElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
            }).OfType<T>().ToList();
        }
    }
}
