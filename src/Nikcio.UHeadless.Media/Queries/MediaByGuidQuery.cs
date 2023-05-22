using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Queries;

/// <summary>
/// Implements the <see cref="MediaByGuid" /> query
/// </summary>
/// <typeparam name="TMedia"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class MediaByGuidQuery<TMedia, TProperty>
    where TMedia : IMedia<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets a Media item by guid
    /// </summary>
    /// <param name="MediaRepository"></param>
    /// <param name="id"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets a Media item by guid.")]
    [UseFiltering]
    [UseSorting]
    public virtual TMedia? MediaByGuid([Service] IMediaRepository<TMedia, TProperty> MediaRepository,
                                        [GraphQLDescription("The id to fetch.")] Guid id,
                                        [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return MediaRepository.GetMedia(x => x?.GetById(preview, id));
    }
}