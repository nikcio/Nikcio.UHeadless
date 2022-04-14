﻿using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public class BasicProperty : Property
    {
        private readonly CreatePropertyValue createPropertyValue;

        /// <inheritdoc/>
        public BasicProperty(CreateProperty createProperty, IPropertyValueFactory propertyValueFactory) : base(createProperty)
        {
            publishedProperty = createProperty.PublishedProperty;
            this.propertyValueFactory = propertyValueFactory;
            createPropertyValue = new CreatePropertyValue(createProperty.PublishedContent, createProperty.PublishedProperty, createProperty.Culture ?? "");
        }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the alias of a property.")]
        public virtual string? Alias => publishedProperty.Alias;

        /// <inheritdoc/>
        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of a property.")]
        public virtual object? Value => propertyValueFactory.GetPropertyValue(createPropertyValue);

        /// <inheritdoc/>
        [GraphQLDescription("Gets the editor alias of a property.")]
        public virtual string? EditorAlias => publishedProperty.PropertyType.EditorAlias;

        /// <summary>
        /// The published property
        /// </summary>
        protected readonly IPublishedProperty publishedProperty;

        /// <summary>
        /// A factory for creating property values
        /// </summary>
        protected readonly IPropertyValueFactory propertyValueFactory;
    }
}
