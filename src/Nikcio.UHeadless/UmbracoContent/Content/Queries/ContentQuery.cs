using System;
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Queries {
    /// <summary>
    /// The base implementation of the content queries
    /// </summary>
    /// <typeparam name="TContent"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class ContentQuery<TContent, TProperty>
        where TContent : IContent<TProperty>
        where TProperty : IProperty {
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
        public virtual IEnumerable<TContent?> GetContentAtRoot([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                               [GraphQLDescription("The culture.")] string? culture = null,
                                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
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
        public virtual TContent? GetContentByGuid([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                  [GraphQLDescription("The id to fetch.")] Guid id,
                                                  [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                  [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
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
        public virtual TContent? GetContentById([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                [GraphQLDescription("The id to fetch.")] int id,
                                                [GraphQLDescription("The culture to fetch.")] string? culture = null,
                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
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
        public virtual TContent? GetContentByRoute([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                   [GraphQLDescription("The route to fetch.")] string route,
                                                   [GraphQLDescription("The culture.")] string? culture = null,
                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false) {
            return contentRepository.GetContent(x => x?.GetByRoute(preview, route, culture: culture), culture);
        }

        /// <summary>
        /// Gets all the content items by content type (Missing preview)
        /// </summary>
        /// <param name="contentRepository"></param>
        /// <param name="contentType"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets all the content items by content type.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TContent?> GetContentByContentType([Service] IContentRepository<TContent, TProperty> contentRepository,
                                                               [GraphQLDescription("The contentType to fetch.")] string contentType,
                                                               [GraphQLDescription("The culture.")] string? culture = null)
        {
            
            return contentRepository.GetContentList(x => x?.GetByContentType(x?.GetContentType(contentType)), culture);
        }
    }
}