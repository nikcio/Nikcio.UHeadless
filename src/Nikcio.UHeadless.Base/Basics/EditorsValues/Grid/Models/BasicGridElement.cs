using HotChocolate;
using Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;


namespace Nikcio.UHeadless.Base.Basics.EditorsValues.Grid.Models {

    [GraphQLDescription("Represents a grid list item.")]
    public class BasicGridElement : BasicGridElement<BasicProperty> {
        /// <inheritdoc/>
        public BasicGridElement(CreateBasicGridElement createBlockListItem, IPropertyFactory<BasicProperty> propertyFactory) : base(createBlockListItem, propertyFactory) {
        }
    }

    /// <inheritdoc/>
    [GraphQLDescription("Represents a grid list item.")]
    public class BasicGridElement<TProperty> : Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Models.BasicGridElement
        where TProperty : IProperty {
        /// <inheritdoc/>


        [GraphQLDescription("Gets the properties of the nested content.")]
        public virtual List<TProperty?> Properties { get; set; } = new();

        /// <inheritdoc/>
        public BasicGridElement(CreateBasicGridElement createElement, IPropertyFactory<TProperty> propertyFactory) : base(createElement) {

            if (createElement.Content != null) {
                foreach (var property in createElement.Content.Properties) {
                    Properties.Add(propertyFactory.GetProperty(property, createElement.Content, createElement.Culture));
                }
            }
        }


        /// <inheritdoc/>
        [GraphQLDescription("Gets the content properties of the grid list item.")]
        public virtual List<TProperty?> ContentProperties { get; set; } = new();

        /// <inheritdoc/>
        [GraphQLDescription("Gets the setting properties of the grid list item.")]
        public virtual List<TProperty?> SettingsProperties { get; set; } = new();

        /// <summary>
        /// Gets the alias of the content block list item.
        /// </summary>
        [GraphQLDescription("Gets the alias of the content grid list item.")]
        public virtual string? ContentAlias { get; set; }

        /// <summary>
        /// Gets the alias of the settings block list item.
        /// </summary>
        [GraphQLDescription("Gets the alias of the settings grid list item.")]
        public virtual string? SettingsAlias { get; set; }
    }
}