using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public interface IContent<TProperty> : IElement<TProperty>
        where TProperty : IProperty
    {
    }
}