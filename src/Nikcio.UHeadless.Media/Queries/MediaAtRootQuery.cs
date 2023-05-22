using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Queries;

/// <summary>
/// Implements the <see cref="MediaAtRoot" /> query
/// </summary>
/// <typeparam name="TMedia"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class MediaAtRootQuery<TMedia, TProperty>
    where TMedia : IMedia<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets all the Media items at root level
    /// </summary>
    /// <param name="MediaRepository"></param>
    /// <param name="preview"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets all the Media items at root level.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TMedia?> MediaAtRoot([Service] IMediaRepository<TMedia, TProperty> MediaRepository,
                                                    [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return MediaRepository.GetMediaList(x => x?.GetAtRoot(preview));
    }
}