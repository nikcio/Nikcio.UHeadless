using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Elements.Commands;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Properties.Models;
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
        public virtual TMedia? CreateMedia(IPublishedContent media, string? culture) {
            var createElementCommand = new CreateElement(media, culture);
            var createMediaCommand = new CreateMedia(media, culture, createElementCommand);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IMedia<TProperty>>(typeof(TMedia), new object[] { createMediaCommand });
            if (createdContent == null) {
                return default;
            }
            return (TMedia) createdContent;
        }
    }
}
