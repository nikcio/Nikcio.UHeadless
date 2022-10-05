using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Basics.EditorsValues.Grid.Models {

    [GraphQLDescription("Represents nested content.")]
    public class BasicGridModel : BasicGridModel<BasicGridElement> {
        /// <inheritdoc/>
        public BasicGridModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents nested content
    /// </summary>
    /// <typeparam name="BasicGridElement"></typeparam>
    [GraphQLDescription("Represents Grid content.")]
    public class BasicGridModel<BasicGridElement> : PropertyValue
        where BasicGridElement : Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Models.BasicGridElement {
        /// <summary>
        /// Gets the elements of a nested content
        /// </summary>
        [GraphQLDescription("Gets the elements of a nested content.")]
        public virtual List<BasicGridElement>? Elements { get; set; }

        /// <inheritdoc/>
        public BasicGridModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>)?.ToList();
            if (elements == null) {
                return;
            }

            Elements = elements.Select(element => {
                var type = typeof(BasicGridElement);
                return dependencyReflectorFactory.GetReflectedType<BasicGridElement>(type, new object[] { new CreateNestedContentElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
            }).OfType<BasicGridElement>().ToList();
        }
    }


}
