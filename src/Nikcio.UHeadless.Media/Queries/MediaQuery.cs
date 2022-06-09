using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Queries {
    /// <summary>
    /// The base implementation of the Media queries
    /// </summary>
    /// <typeparam name="TMedia"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class MediaQuery<TMedia, TProperty>
        where TMedia : IMedia<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Gets all the Media items at root level
        /// </summary>
        /// <param name="MediaRepository"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets all the Media items at root level.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TMedia?> GetMediaAtRoot([Service] IMediaRepository<TMedia, TProperty> MediaRepository,
                                                               [GraphQLDescription("The culture.")] string? culture = null,
                                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return MediaRepository.GetMediaList(x => x?.GetAtRoot(preview, culture), culture);
        }

        /// <summary>
        /// Gets a Media item by guid
        /// </summary>
        /// <param name="MediaRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a Media item by guid.")]
        [UseFiltering]
        [UseSorting]
        public virtual TMedia? GetMediaByGuid([Service] IMediaRepository<TMedia, TProperty> MediaRepository,
                                                  [GraphQLDescription("The id to fetch.")] Guid id,
                                                  [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                  [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return MediaRepository.GetMedia(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Gets a Media item by id
        /// </summary>
        /// <param name="MediaRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a Media item by id.")]
        [UseFiltering]
        [UseSorting]
        public virtual TMedia? GetMediaById([Service] IMediaRepository<TMedia, TProperty> MediaRepository,
                                                [GraphQLDescription("The id to fetch.")] int id,
                                                [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return MediaRepository.GetMedia(x => x?.GetById(preview, id), culture);
        }
    }
}