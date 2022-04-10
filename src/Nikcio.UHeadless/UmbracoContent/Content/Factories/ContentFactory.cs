using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Elements.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Factories
{
    public class ContentFactory<TContent, TProperty> : IContentFactory<TContent, TProperty>
            where TContent : IContent<TProperty>, new()
            where TProperty : IProperty
    {
        private readonly IDependencyReflectorFactory dependencyReflectorFactory;

        public ContentFactory(IDependencyReflectorFactory dependencyReflectorFactory)
        {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        public TContent? CreateContent(IPublishedContent content, string? culture)
        {
            var createElementCommand = new CreateElement(content, culture);
            var createContentCommand = new CreateContent(content, culture, createElementCommand);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IContent<TProperty>>(typeof(TContent), new object[] { createContentCommand });
            if (createdContent == null)
            {
                return default;
            }
            return (TContent)createdContent;
        }
    }
}
