using Nikcio.UHeadless.Base.Elements.Models;

namespace Nikcio.UHeadless.Content.Models;

/// <summary>
/// Represents a content item
/// </summary>
public interface IContent : IElement
{
    /// <summary>
    /// Redirect information for a content node
    /// </summary>
    public object? Redirect { get; set; }
}