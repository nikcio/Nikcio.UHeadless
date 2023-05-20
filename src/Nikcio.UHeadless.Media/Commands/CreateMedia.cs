using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Media.Commands;

/// <summary>
/// A command to create media
/// </summary>
public class CreateMedia : ICommand
{
    /// <inheritdoc/>
    public CreateMedia(IPublishedContent? media, CreateElement createElement)
    {
        Media = media;
        CreateElement = createElement;
    }

    /// <summary>
    /// The published media
    /// </summary>
    public virtual IPublishedContent? Media { get; set; }

    /// <summary>
    /// The create element command
    /// </summary>
    public virtual CreateElement CreateElement { get; set; }
}
