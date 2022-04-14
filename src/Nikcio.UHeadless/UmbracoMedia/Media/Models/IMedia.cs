using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Elements.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Models {
    /// <summary>
    /// Represents a Media item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a Media item.")]
    public interface IMedia<TProperty> : IElement<TProperty>
        where TProperty : IProperty {
    }
}