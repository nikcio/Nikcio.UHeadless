using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Commands;

/// <summary>
/// Command for creating an element
/// </summary>
public class CreateNestedContentElement : ICommand
{
    /// <inheritdoc/>
    public CreateNestedContentElement(IPublishedContent content, IPublishedElement element, string? culture, string? segment, Fallback fallback)
    {
        Content = content;
        Element = element;
        Culture = culture;
        Segment = segment;
        Fallback = fallback;
    }

    /// <summary>
    /// The <see cref="IPublishedContent"/>
    /// </summary>
    public virtual IPublishedContent Content { get; set; }

    /// <summary>
    /// The <see cref="IPublishedElement"/>
    /// </summary>
    public virtual IPublishedElement Element { get; set; }

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
    public virtual Fallback Fallback { get; set; }
}
