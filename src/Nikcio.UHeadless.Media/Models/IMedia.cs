using HotChocolate;
using Nikcio.UHeadless.Elements.Models;
using Nikcio.UHeadless.Properties.Models;

namespace Nikcio.UHeadless.Media.Models {
    /// <summary>
    /// Represents a Media item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a Media item.")]
    public interface IMedia<TProperty> : IElement<TProperty>
        where TProperty : IProperty {
    }
}