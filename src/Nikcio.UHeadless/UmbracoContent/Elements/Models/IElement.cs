using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Elements.Models
{
    /// <summary>
    /// Represents a element item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a element item.")]
    public interface IElement<TProperty>
        where TProperty : IProperty
    {

    }
}
