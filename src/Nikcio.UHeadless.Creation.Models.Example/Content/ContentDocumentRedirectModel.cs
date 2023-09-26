using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;

namespace Nikcio.UHeadless.Creation.Models.Example.Content;

/// <summary>
/// Represents a content redirect
/// </summary>
public class ContentDocumentRedirectModel : ContentRedirect
{
    /// <inheritdoc/>
    public ContentDocumentRedirectModel(CreateContentRedirect createContentRedirect) : base(createContentRedirect)
    {
        Url = createContentRedirect.RedirectUrl;
        IsPermanent = createContentRedirect.IsPermanent;
    }

    /// <summary>
    /// The url to redirect to
    /// </summary>
    public virtual string Url { get; set; }

    /// <summary>
    /// Is the redirect permanent
    /// </summary>
    public virtual bool IsPermanent { get; set; }
}
