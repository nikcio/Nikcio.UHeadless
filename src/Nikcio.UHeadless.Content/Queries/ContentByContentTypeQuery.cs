using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;

namespace Nikcio.UHeadless.Content.Queries;

/// <summary>
/// Implements the <see cref="ContentByContentType" /> query
/// </summary>
/// <typeparam name="TContent"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class ContentByContentTypeQuery<TContent, TProperty>
    where TContent : IContent
    where TProperty : IProperty
{
    /// <summary>
    /// Gets all the content items by content type (Missing preview)
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="contentType"></param>
    /// <param name="culture"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all the content items by content type.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> ContentByContentType([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The contentType to fetch.")] string contentType,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("The property variation segment")] string? segment = null,
                                                           [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return contentRepository.GetContentList(x =>
        {
            var publishedContentType = x?.GetContentType(contentType);
            return publishedContentType != null ? x?.GetByContentType(publishedContentType) : default;
        }, culture, segment, fallback?.ToFallback());
    }
}