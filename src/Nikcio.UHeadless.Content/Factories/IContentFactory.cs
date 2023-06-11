using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Content.Factories;

/// <summary>
/// A factory for creating content
/// </summary>
/// <typeparam name="TContent"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public interface IContentFactory<TContent, TProperty> : IElementFactory<TContent, TProperty>
        where TContent : IContent
        where TProperty : IProperty
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
