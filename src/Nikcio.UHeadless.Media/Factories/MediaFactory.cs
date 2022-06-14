using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Media.Factories {
    /// <inheritdoc/>
    public class MediaFactory<TMedia, TProperty> : IMediaFactory<TMedia, TProperty>
            where TMedia : IMedia<TProperty>
            where TProperty : IProperty {
        /// <summary>
        /// A factory for creating object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public MediaFactory(IDependencyReflectorFactory dependencyReflectorFactory) {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public TMedia? CreateElement(IPublishedContent? element, string? culture) {
            var createElementCommand = new CreateElement(element, culture);
            var createMediaCommand = new CreateMedia(element, culture, createElementCommand);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IMedia<TProperty>>(typeof(TMedia), new object[] { createMediaCommand });
            return createdContent == null ? default : (TMedia) createdContent;
        }

        /// <inheritdoc/>
        public virtual TMedia? CreateMedia(IPublishedContent media, string? culture) {
            return CreateElement(media, culture);
        }
    }
}
