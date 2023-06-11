using HotChocolate;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Members.Models;

/// <summary>
/// Represents a member
/// </summary>
/// <typeparam name="TProperty"></typeparam>
[GraphQLDescription("Represents a member.")]
public interface IMember<TProperty> : IElement
    where TProperty : IProperty
{
}