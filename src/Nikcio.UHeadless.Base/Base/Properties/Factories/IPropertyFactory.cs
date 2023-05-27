using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Factories;

/// <summary>
/// A factory to create properties
/// </summary>
public interface IPropertyFactory<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets a property from a <see cref="IPublishedProperty"/>
    /// </summary>
    /// <param name="property">The <see cref="IPublishedProperty"/></param>
    /// <param name="publishedContent">The <see cref="IPublishedContent"/></param>
    /// <param name="culture">The culture</param>
    /// <param name="segment">The segment</param>
    /// <param name="fallback">The fallback tactic</param>
    /// <returns></returns>
    TProperty? GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture, string? segment, Fallback? fallback);

    /// <summary>
    /// Creates properties based on published content
    /// </summary>
    /// <param name="publishedContent"></param>
    /// <param name="culture"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <returns></returns>
    IEnumerable<TProperty?> CreateProperties(IPublishedContent publishedContent, string? culture, string? segment, Fallback? fallback);
}