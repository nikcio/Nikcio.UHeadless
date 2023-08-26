namespace Nikcio.UHeadless.Content.Models;

/// <summary>
/// Represents a redirectable entity
/// </summary>
public interface IRedirectableEntity<TRedirect>
    where TRedirect : IRedirect
{
    /// <summary>
    /// Redirect information for a content node
    /// </summary>
    public TRedirect? Redirect { get; set; }
}