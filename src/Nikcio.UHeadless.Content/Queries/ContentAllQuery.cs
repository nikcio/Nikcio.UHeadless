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
/// Implements the <see cref="ContentAll" /> query
/// </summary>
/// <typeparam name="TContent"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class ContentAllQuery<TContent, TProperty>
    where TContent : IContent<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets all the content items available
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="culture"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all the content items available.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TContent?> ContentAll([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                           [GraphQLDescription("The culture.")] string? culture = null,
                                                           [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return contentRepository.GetContentList(x =>
        {
            return x?.GetAtRoot(preview, culture).SelectMany(content => content.Descendants(culture))
                .Concat(x?.GetAtRoot(preview, culture) ?? Enumerable.Empty<IPublishedContent>());
        }, culture);
    }
}