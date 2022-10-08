using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Base.Elements.Models;

/// <summary>
/// Represents a element item
/// </summary>
/// <typeparam name="TProperty"></typeparam>
[GraphQLDescription("Represents a element item.")]
public interface IElement<TProperty>
    where TProperty : IProperty
{

}
