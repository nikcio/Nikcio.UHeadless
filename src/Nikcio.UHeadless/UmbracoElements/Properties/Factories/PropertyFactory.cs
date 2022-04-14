using System.Collections.Generic;
using System.Linq;
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Factories {
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
            if (createdProperty == null) {
                return default;
            }
            return (TProperty) createdProperty;
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TProperty?> CreateProperties(IPublishedContent publishedContent, string? culture) {
            return publishedContent.Properties.Select(IPublishedProperty => GetProperty(IPublishedProperty, publishedContent, culture));
        }

    }
}
