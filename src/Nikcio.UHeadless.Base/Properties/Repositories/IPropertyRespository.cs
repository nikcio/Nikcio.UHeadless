using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Base.Properties.Repositories;

/// <summary>
/// A repository for getting properties
/// </summary>
public interface IPropertyRespository<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets properties based on a fetch method
    /// </summary>
    /// <param name="fetch"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    IEnumerable<TProperty?> GetContentItemProperties(Func<IPublishedContentCache?, IPublishedContent?> fetch, string? culture);

    /// <summary>
    /// Gets properties based on a fetch method
    /// </summary>
    /// <param name="fetch"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    IEnumerable<IEnumerable<TProperty?>?> GetContentItemsProperties(Func<IPublishedContentCache?, IEnumerable<IPublishedContent>?> fetch, string? culture);

    /// <summary>
    /// Gets properties based on <see cref="IPublishedContent"/>
    /// </summary>
    /// <param name="content">The <see cref="IPublishedContent"/></param>
    /// <param name="culture">The culture</param>
    /// <returns></returns>
    IEnumerable<TProperty?> GetProperties(IPublishedContent content, string? culture);
}