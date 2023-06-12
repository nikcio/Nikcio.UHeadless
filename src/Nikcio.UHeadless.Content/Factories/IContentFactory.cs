using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Content.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Content.Factories;

/// <summary>
/// A factory for creating content
/// </summary>
/// <typeparam name="TContent"></typeparam>
public interface IContentFactory<TContent> : IElementFactory<TContent>
        where TContent : IContent
{
    /// <summary>
    /// Creates a content
    /// </summary>
    /// <param name="content"></param>
    /// <param name="culture"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <returns></returns>
    TContent? CreateContent(IPublishedContent? content, string? culture, string? segment, Fallback? fallback);
}
