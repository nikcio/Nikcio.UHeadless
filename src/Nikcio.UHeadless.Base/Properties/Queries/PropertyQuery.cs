using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Base.Properties.Repositories;

namespace Nikcio.UHeadless.Base.Properties.Queries;

/// <summary>
/// A base for all property queries
/// </summary>
/// <typeparam name="TProperty"></typeparam>
public class PropertyQuery<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets all the content items properties at root level
    /// </summary>
    /// <param name="propertyRespository"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all the content items properties at root level.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<IEnumerable<TProperty?>?> GetPropertiesAtRoot([Service] IPropertyRespository<TProperty> propertyRespository,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return propertyRespository.GetContentItemsProperties(x => x?.GetAtRoot(preview, culture), culture);
    }

    /// <summary>
    /// Get properties by content guid
    /// </summary>
    /// <param name="propertyRespository"></param>
    /// <param name="id"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Get properties by content guid.")]
    [UsePaging]
    [UseFiltering]
    public virtual IEnumerable<TProperty?>? GetPropertiesByGuid([Service] IPropertyRespository<TProperty> propertyRespository,
                                                               [GraphQLDescription("The guid of the content item.")] Guid id,
                                                               [GraphQLDescription("The culture of the content item.")] string? culture = null,
                                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return propertyRespository.GetContentItemProperties(x => x?.GetById(preview, id), culture);
    }

    /// <summary>
    /// Get properties based by content id
    /// </summary>
    /// <param name="propertyRespository"></param>
    /// <param name="id"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Get properties based by content id.")]
    [UsePaging]
    [UseFiltering]
    public virtual IEnumerable<TProperty?>? GetPropertiesById([Service] IPropertyRespository<TProperty> propertyRespository,
                                                             [GraphQLDescription("The id of the content item.")] int id,
                                                             [GraphQLDescription("The culture of the content item.")] string? culture = null,
                                                             [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return propertyRespository.GetContentItemProperties(x => x?.GetById(preview, id), culture);
    }

    /// <summary>
    /// Get properties by content route
    /// </summary>
    /// <param name="propertyRespository"></param>
    /// <param name="route"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Get properties by content route.")]
    [UsePaging]
    [UseFiltering]
    public virtual IEnumerable<TProperty?>? GetPropertiesByRoute([Service] IPropertyRespository<TProperty> propertyRespository,
                                                                [GraphQLDescription("The route of the content item.")] string route,
                                                                [GraphQLDescription("The culture of the content item.")] string? culture = null,
                                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return propertyRespository.GetContentItemProperties(x => x?.GetByRoute(preview, route, culture: culture), culture);
    }

    /// <summary>
    /// Gets all the content items properties by content type (Missing preview)
    /// </summary>
    /// <param name="propertyRepository"></param>
    /// <param name="contentType"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets properties all the content items by content type.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<IEnumerable<TProperty?>?> GetPropertiesByContentType([Service] IPropertyRespository<TProperty> propertyRepository,
                                                           [GraphQLDescription("The contentType to fetch.")] string contentType,
                                                           [GraphQLDescription("The culture.")] string? culture = null)
    {
        return propertyRepository.GetContentItemsProperties(x =>
        {
            var publishedContentType = x?.GetContentType(contentType);
            return publishedContentType != null ? x?.GetByContentType(publishedContentType) : default;
        }, culture);
    }
}