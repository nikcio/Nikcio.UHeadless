using HotChocolate;
using Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;


namespace Nikcio.UHeadless.Base.Basics.EditorsValues.Grid.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a grid element.")]
    public class BasicGridElement : BasicGridElement<BasicProperty> {
        /// <inheritdoc/>
        public BasicGridElement(CreateGridElement createGridElement, IPropertyFactory<BasicProperty> propertyFactory) : base(createGridElement, propertyFactory) {
        }
    }

    /// <inheritdoc/>
    [GraphQLDescription("Represents a grid element.")]
    public class BasicGridElement<TProperty> : GridElement
        where TProperty : IProperty {

        /// <summary>
        /// Gets the properties of the grid element.
        /// </summary>
        [GraphQLDescription("Gets the properties of the grid element.")]
        public virtual List<TProperty?> Properties { get; set; } = new();

        /// <inheritdoc/>
        public BasicGridElement(CreateGridElement createGridElement, IPropertyFactory<TProperty> propertyFactory) : base(createGridElement) {
            if (createGridElement.Content == null) {
                return;
            }

            foreach (var property in createGridElement.Content.Properties) {
                Properties.Add(propertyFactory.GetProperty(property, createGridElement.Content, createGridElement.Culture));
            }
        }
    }
}