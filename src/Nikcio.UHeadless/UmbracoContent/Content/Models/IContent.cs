using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Elements.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models {
    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public interface IContent<TProperty> : IElement<TProperty>
        where TProperty : IProperty {
    }
}