using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Commands;
using Nikcio.UHeadless.UmbracoContent.ContentTypes.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.ContentTypes.Factories
{
    public class ContentTypeFactory<TContentType> : IContentTypeFactory<TContentType>
        where TContentType : IContentType
    {
        private readonly IDependencyReflectorFactory dependencyReflectorFactory;

        public ContentTypeFactory(IDependencyReflectorFactory dependencyReflectorFactory)
        {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

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
