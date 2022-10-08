using Nikcio.UHeadless.Core.Commands;

namespace Nikcio.UHeadless.Content.Commands;

/// <summary>
/// A command to create a content redirect
/// </summary>
public class CreateContentRedirect : ICommand
{
    /// <summary>
    /// The url to redirect to
    /// </summary>
    public virtual string RedirectUrl { get; set; }

    /// <summary>
    /// Is the redirect permanent
    /// </summary>
    public virtual bool IsPermanent { get; set; }

    /// <inheritdoc/>
    public CreateContentRedirect(string redirectUrl, bool isPermanent)
    {
        RedirectUrl = redirectUrl;
        IsPermanent = isPermanent;
    }

}
