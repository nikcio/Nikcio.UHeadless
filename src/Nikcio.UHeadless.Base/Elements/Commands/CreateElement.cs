using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Elements.Commands;

/// <summary>
/// A command to create a element
/// </summary>
public class CreateElement : ICommand
{
    /// <inheritdoc/>
    public CreateElement(IPublishedContent? content, string? culture)
    {
        Content = content;
        Culture = culture;
    }

    /// <summary>
    /// The published content
    /// </summary>
    public virtual IPublishedContent? Content { get; set; }

    /// <summary>
    /// The culture
    /// </summary>
    public virtual string? Culture { get; set; }
}
