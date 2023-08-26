using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Elements.Models;

/// <inheritdoc/>
public abstract class Element : IElement
{
    /// <inheritdoc/>
    protected Element(CreateElement createElement)
    {
        Content = createElement.Content;
        Culture = createElement.Culture;
        Segment = createElement.Segment;
        Fallback = createElement.Fallback;
    }

    /// <summary>
    /// The content
    /// </summary>
    protected virtual IPublishedContent? Content { get; }

    /// <summary>
    /// The culture
    /// </summary>
    protected virtual string? Culture { get; }

    /// <summary>
    /// The segment
    /// </summary>
    protected virtual string? Segment { get; }

    /// <summary>
    /// The property fallback
    /// </summary>
    internal protected virtual Fallback? Fallback { get; }

    /// <summary>
    /// Gets the <see cref="IPublishedContent"/> for the <see cref="Element"/>
    /// </summary>
    /// <returns></returns>
    internal IPublishedContent? GetContent()
    {
        return Content;
    }

    /// <summary>
    /// Gets the culture for the <see cref="Element"/>
    /// </summary>
    /// <returns></returns>
    internal string? GetCulture()
    {
        return Culture;
    }

    /// <summary>
    /// Gets the segment for the <see cref="Element"/>
    /// </summary>
    /// <returns></returns>
    internal string? GetSegment()
    {
        return Segment;
    }

    /// <summary>
    /// Gets the <see cref="Fallback"/> for the <see cref="Element"/>
    /// </summary>
    /// <returns></returns>
    internal Fallback? GetFallback()
    {
        return Fallback;
    }
}
