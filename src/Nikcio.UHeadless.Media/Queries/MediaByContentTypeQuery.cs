using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Queries;

/// <summary>
/// Implements the <see cref="MediaByContentType" /> query
/// </summary>
/// <typeparam name="TMedia"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class MediaByContentTypeQuery<TMedia, TProperty>
    where TMedia : IMedia<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets all the media items by content type (Missing preview)
    /// </summary>
    /// <param name="mediaRepository"></param>
    /// <param name="contentType"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all the media items by content type.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TMedia?> MediaByContentType([Service] IMediaRepository<TMedia, TProperty> mediaRepository,
                                                           [GraphQLDescription("The contentType to fetch.")] string contentType)
    {
        return mediaRepository.GetMediaList(x =>
        {
            var publishedContentType = x?.GetContentType(contentType);
            return publishedContentType != null ? x?.GetByContentType(publishedContentType) : default;
        });
    }
}