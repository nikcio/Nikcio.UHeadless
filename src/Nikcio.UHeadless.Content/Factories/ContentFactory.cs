using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Content.Factories {
    /// <inheritdoc/>
    public class ContentFactory<TContent, TProperty> : IContentFactory<TContent, TProperty>
            where TContent : IContent<TProperty>
            where TProperty : IProperty {
        /// <summary>
        /// A factory that can create object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public ContentFactory(IDependencyReflectorFactory dependencyReflectorFactory) {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual TContent? CreateContent(IPublishedContent? content, string? culture) {
            return CreateElement(content, culture);
        }

        /// <inheritdoc/>
        public TContent? CreateElement(IPublishedContent? element, string? culture) {
            var createElementCommand = new CreateElement(element, culture);
            var createContentCommand = new CreateContent(element, culture, createElementCommand);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IContent<TProperty>>(typeof(TContent), new object[] { createContentCommand });
            return createdContent == null ? default : (TContent) createdContent;
        }
    }
}
