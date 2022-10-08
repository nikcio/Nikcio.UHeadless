using Nikcio.UHeadless.Base.Elements.Factories;
using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Factories;

/// <summary>
/// A factory to create properties
/// </summary>
public interface IPropertyFactory<TProperty> : IElementFactory<IElement<TProperty>, TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets a property from a <see cref="IPublishedProperty"/>
    /// </summary>
    /// <param name="property">The <see cref="IPublishedProperty"/></param>
    /// <param name="publishedContent">The <see cref="IPublishedContent"/></param>
    /// <param name="culture">The culture</param>
    /// <returns></returns>
    TProperty? GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture);

    /// <summary>
    /// Creates properties based on published content
    /// </summary>
    /// <param name="publishedContent"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    IEnumerable<TProperty?> CreateProperties(IPublishedContent publishedContent, string? culture);
}