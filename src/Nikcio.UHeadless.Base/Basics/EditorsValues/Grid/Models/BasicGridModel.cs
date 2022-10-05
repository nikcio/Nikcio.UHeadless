using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Models;
using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Basics.EditorsValues.Grid.Models {

    /// <summary>
    /// Represents a grid
    /// </summary>
    [GraphQLDescription("Represents a grid.")]
    public class BasicGridModel : BasicGrid<BasicGridElement> {
        /// <inheritdoc/>
        public BasicGridModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a grid
    /// </summary>
    /// <typeparam name="TGridElement"></typeparam>
    [GraphQLDescription("Represents Grid content.")]
    public class BasicGrid<TGridElement> : PropertyValue
        where TGridElement : GridElement {

        /// <summary>
        /// Gets the elements of a grid
        /// </summary>
        [GraphQLDescription("Gets the elements of a grid.")]
        public virtual List<TGridElement>? Elements { get; set; }

        /// <inheritdoc/>
        public BasicGrid(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var propertyValue = createPropertyValue.Property.GetValue();
            if (propertyValue == null) {
                return;
            }

            var value = (IEnumerable<IPublishedElement>)propertyValue;
            Elements = value?.Select(element => {
                var type = typeof(TGridElement);
                return dependencyReflectorFactory.GetReflectedType<TGridElement>(type, new object[] { new CreateNestedContentElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
            }).OfType<TGridElement>().ToList();
        }
    }


}
