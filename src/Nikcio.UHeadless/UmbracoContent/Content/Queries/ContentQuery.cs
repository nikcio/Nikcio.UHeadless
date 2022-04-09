using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Content.Queries
{
    /// <summary>
    /// The base implementation of the content queries
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class ContentQuery<T, TProperty>
        where T : IContent<TProperty>, new()
        where TProperty : IProperty
    {
        /// <summary>
        /// Gets all the content items at root level
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets all the content items at root level.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<T> GetContentAtRoot([Service] IContentRepository<T, TProperty> contentRepository,
                                                               [GraphQLDescription("The culture.")] string? culture = null,
                                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContentList(x => x?.GetAtRoot(preview, culture), culture);
        }

        /// <summary>
        /// Gets a content item by guid
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a content item by guid.")]
        [UseFiltering]
        [UseSorting]
        public virtual T? GetContentByGuid([Service] IContentRepository<T, TProperty> contentRepository,
                                                  [GraphQLDescription("The id to fetch.")] Guid id,
                                                  [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                  [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContent(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Gets a content item by id
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a content item by id.")]
        [UseFiltering]
        [UseSorting]
        public virtual T? GetContentById([Service] IContentRepository<T, TProperty> contentRepository,
                                                [GraphQLDescription("The id to fetch.")] int id,
                                                [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContent(x => x?.GetById(preview, id), culture);
        }

        /// <summary>
        /// Gets a content item by route
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="route"></param>
        /// <param name="culture"></param>
        /// <param name="preview"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a content item by route.")]
        [UseFiltering]
        [UseSorting]
        public virtual T? GetContentByRoute([Service] IContentRepository<T, TProperty> contentRepository,
                                                   [GraphQLDescription("The route to fetch.")] string route,
                                                   [GraphQLDescription("The culture.")] string? culture = null,
                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContent(x => x?.GetByRoute(preview, route, culture: culture), culture);
        }
    }
}