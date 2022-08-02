﻿using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Factories {
    /// <inheritdoc/>
    public class PropertyFactory<TProperty> : IPropertyFactory<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// A factory for creating objects with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public PropertyFactory(IDependencyReflectorFactory dependencyReflectorFactory) {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual TProperty? GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture) {
            var createPropertyCommand = new CreateProperty(property, culture, publishedContent);

            var createdProperty = dependencyReflectorFactory.GetReflectedType<IProperty>(typeof(TProperty), new object[] { createPropertyCommand });
            return createdProperty == null ? default : (TProperty) createdProperty;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty?> CreateProperties(IPublishedContent publishedContent, string? culture) {
            return publishedContent.Properties.Select(IPublishedProperty => GetProperty(IPublishedProperty, publishedContent, culture));
        }

        /// <inheritdoc/>
        public IElement<TProperty>? CreateElement(IPublishedContent? element, string? culture) {
            return null;
        }
    }
}
