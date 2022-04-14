using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Commands;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.ContentTypes.Factories
{
    /// <inheritdoc/>
    public class ContentTypeFactory<TContentType> : IContentTypeFactory<TContentType>
        where TContentType : IContentType
    {
        /// <summary>
        /// A factory that can create objects with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public ContentTypeFactory(IDependencyReflectorFactory dependencyReflectorFactory)
        {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public TContentType? CreateContentType(IPublishedContentType publishedContentType)
        {
            var createContentTypeCommand = new CreateContentType(publishedContentType);

            var createdContentType = dependencyReflectorFactory.GetReflectedType<IContentType>(typeof(TContentType), new object[] { createContentTypeCommand });

            if (createdContentType == null)
            {
                return default;
            }

            return (TContentType)createdContentType;
        }
    }
}
