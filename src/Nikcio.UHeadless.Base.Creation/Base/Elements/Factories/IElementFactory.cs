using Nikcio.UHeadless.Base.Elements.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Elements.Factories;

/// <summary>
/// A factory for creating an element
/// </summary>
/// <typeparam name="TElement"></typeparam>
public interface IElementFactory<TElement>
    where TElement : IElement
{
    /// <summary>
    /// Creates an element
    /// </summary>
    /// <param name="element"></param>
    /// <param name="culture"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    TElement? CreateElement(IPublishedContent? element, string? culture, string? segment, Fallback? fallback);
}
