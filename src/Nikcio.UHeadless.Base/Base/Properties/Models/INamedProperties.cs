namespace Nikcio.UHeadless.Base.Properties.Models;

/// <summary>
/// Represents a property that can be queried by the alias name
/// </summary>
[GraphQLDescription("Represents a property that can be queried by the alias name.")]
public interface INamedProperties
{
}

/// <summary>
/// Only used to make <see cref="INamedProperties"/> possible. Do not use anywhere else!
/// </summary>
public sealed class NamedProperties : INamedProperties
{
}