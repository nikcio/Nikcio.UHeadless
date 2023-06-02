using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;

namespace Nikcio.UHeadless.Content.Queries;

/// <summary>
/// Implements the <see cref="ContentById" /> query
/// </summary>
/// <typeparam name="TContent"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class ContentByIdQuery<TContent, TProperty>
    where TContent : IContent<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets a content item by id
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="id"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets a content item by id.")]
    [UseFiltering]
    [UseSorting]
    public virtual TContent? ContentById([Service] IContentRepository<TContent, TProperty> contentRepository,
                                            [GraphQLDescription("The id to fetch.")] int id,
                                            [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                            [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
                                            [GraphQLDescription("The property variation segment")] string? segment = null,
                                            [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return contentRepository.GetContent(x => x?.GetById(preview, id), culture, segment, fallback?.ToFallback());
    }
}