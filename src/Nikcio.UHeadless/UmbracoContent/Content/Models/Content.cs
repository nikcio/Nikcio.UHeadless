using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoElements.Elements.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models {
    /// <summary>
    /// A base for content
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class Content<TProperty> : Element<TProperty>, IContent<TProperty>
        where TProperty : IProperty {
        /// <inheritdoc/>
        protected Content(CreateContent createContent, IPropertyFactory<TProperty> propertyFactory) : base(createContent.CreateElement, propertyFactory) {
        }
    }
}
