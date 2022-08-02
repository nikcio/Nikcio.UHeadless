using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Basics.Properties.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public class BasicProperty : Property {
        private readonly CreatePropertyValue _createPropertyValue;

        /// <inheritdoc/>
        public BasicProperty(CreateProperty createProperty, IPropertyValueFactory propertyValueFactory) : base(createProperty) {
            if(createProperty is CreatePublishedProperty createPublishedProperty) {
                publishedProperty = createPublishedProperty.PublishedProperty;
                this.propertyValueFactory = propertyValueFactory;
                _createPropertyValue = new CreatePublishedPropertyValue(createPublishedProperty.PublishedContent, createPublishedProperty.PublishedProperty, createProperty.Culture ?? "");
            }else if(createProperty is CreateRawProperty createRawProperty) {
                property = createRawProperty.Property;
                this.propertyValueFactory = propertyValueFactory;
                _createPropertyValue = new CreateRawPropertyValue(createRawProperty.ContentBase, createRawProperty.Property, createProperty.Culture ?? "");
            } else {
                throw new ArgumentException("createProperty type not found", nameof(createProperty));
            }
        }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the alias of a property.")]
        public virtual string? Alias => publishedProperty?.Alias ?? property?.Alias ?? "Unknown";

        /// <inheritdoc/>
        [GraphQLDescription("Gets the value of a property.")]
        public virtual PropertyValue? Value => propertyValueFactory.GetPropertyValue(_createPropertyValue);

        /// <inheritdoc/>
        [GraphQLDescription("Gets the editor alias of a property.")]
        public virtual string? EditorAlias => publishedProperty?.PropertyType.EditorAlias ?? property?.PropertyType.PropertyEditorAlias ?? "Unknown";

        /// <summary>
        /// The published property
        /// </summary>
        protected readonly IPublishedProperty? publishedProperty;

        /// <summary>
        /// The property
        /// </summary>
        protected readonly Umbraco.Cms.Core.Models.IProperty? property;

        /// <summary>
        /// A factory for creating property values
        /// </summary>
        protected readonly IPropertyValueFactory propertyValueFactory;
    }
}
