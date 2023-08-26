using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Repositories;

/// <summary>
/// A repository for getting properties
/// </summary>
public interface IPropertyRespository<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets properties based on <see cref="IPublishedContent"/>
    /// </summary>
    /// <param name="content">The <see cref="IPublishedContent"/></param>
    /// <param name="culture">The culture</param>
    /// <param name="segment">The segment</param>
    /// <param name="fallback">The fallback tactic</param>
    /// <returns></returns>
    IEnumerable<TProperty?> GetProperties(IPublishedContent content, string? culture, string? segment, Fallback? fallback);
}