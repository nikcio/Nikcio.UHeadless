using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.Content.Models;

/// <summary>
/// Represents properties on content
/// </summary>
[GraphQLDescription("Represents properties on content.")]
public interface IContentProperties
{
    public string MyProperty { get; set; }
}

internal class ImplementingClass : IContentProperties
{
    public string MyProperty { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
