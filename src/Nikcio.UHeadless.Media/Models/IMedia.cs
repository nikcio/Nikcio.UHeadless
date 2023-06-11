using HotChocolate;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Media.Models;

/// <summary>
/// Represents a Media item
/// </summary>
/// <typeparam name="TProperty"></typeparam>
[GraphQLDescription("Represents a Media item.")]
public interface IMedia<TProperty> : IElement
    where TProperty : IProperty
{
}