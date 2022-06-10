using HotChocolate;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Elements.Models;
using Nikcio.UHeadless.Properties.Factories;
using Nikcio.UHeadless.Properties.Models;

namespace Nikcio.UHeadless.Content.Models {
    /// <summary>
    /// A base for content
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public abstract class Content<TProperty> : Element<TProperty>, IContent<TProperty>
        where TProperty : IProperty {
        /// <inheritdoc/>
        protected Content(CreateContent createContent, IPropertyFactory<TProperty> propertyFactory) : base(createContent.CreateElement, propertyFactory) {
        }

        /// <inheritdoc/>
        [GraphQLDescription("Redirect information for a content node")]
        public object? Redirect { get; set; }
    }
}
