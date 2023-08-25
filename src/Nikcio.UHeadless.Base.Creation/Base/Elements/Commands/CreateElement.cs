using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Elements.Commands;

/// <summary>
/// A command to create a element
/// </summary>
public class CreateElement : ICommand
{
    /// <inheritdoc/>
    public CreateElement(IPublishedContent? content, string? culture, string? segment, Fallback? fallback)
    {
        Content = content;
        Culture = culture;
        Segment = segment;
        Fallback = fallback;
    }

    /// <summary>
    /// The published content
    /// </summary>
    public virtual IPublishedContent? Content { get; set; }

    /// <summary>
    /// The culture
    /// </summary>
    public virtual string? Culture { get; set; }

    /// <summary>
    /// The segment
    /// </summary>
    public virtual string? Segment { get; set; }

    /// <summary>
    /// The fallback tactic
    /// </summary>
    public virtual Fallback? Fallback { get; set; }
}
