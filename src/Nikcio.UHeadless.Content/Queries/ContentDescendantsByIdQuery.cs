using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Content.Queries;

/// <summary>
/// Implements the <see cref="ContentDescendantsById" /> query
/// </summary>
/// <typeparam name="TContent"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class ContentDescendantsByIdQuery<TContent, TProperty>
    where TContent : IContent<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets descendants on a content item selected by id
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="id"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets descendants on a content item selected by id.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> ContentDescendantsById([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The id to fetch.")] int id,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return contentRepository.GetContentList(x => x?.GetById(preview, id)?.Descendants(culture) ?? Enumerable.Empty<IPublishedContent>(), culture);
    }
}