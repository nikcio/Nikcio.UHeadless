using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;

namespace Nikcio.UHeadless.Base.Properties.Models;

/// <inheritdoc/>
[GraphQLDescription("Represents a property.")]
public abstract class Property : IProperty
{
    /// <inheritdoc/>
    protected Property(CreateProperty _)
    {
    }
}
