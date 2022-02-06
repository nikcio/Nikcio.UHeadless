using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using System;
using System.Collections.Generic;

namespace Nikcio.UHeadless.UmbracoContent.Content.Queries
{
    [ExtendObjectType(typeof(Query))]
    [GraphQLDescription("Queries for Umbraco content.")]
    public class ContentQuery
    {
        [GraphQLDescription("Gets a content item by id.")]
        [UseFiltering]
        [UseSorting]
        public IContentGraphType GetContentById([Service] IContentRepository contentRepository,
                                                [GraphQLDescription("The id to fetch.")] int id,
                                                [GraphQLDescription("The culture to fetch.")] string culture = null,
                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetById(preview, id), culture);
        }

        [GraphQLDescription("Gets a content item by guid.")]
        [UseFiltering]
        [UseSorting]
        public IContentGraphType GetContentByGuid([Service] IContentRepository contentRepository,
                                                  [GraphQLDescription("The id to fetch.")] Guid id,
                                                  [GraphQLDescription("The culture to fetch.")] string culture = null,
                                                  [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetById(preview, id), culture);
        }

        [GraphQLDescription("Gets a content item by route.")]
        [UseFiltering]
        [UseSorting]
        public IContentGraphType GetContentByRoute([Service] IContentRepository contentRepository,
                                                   [GraphQLDescription("The route to fetch.")] string route,
                                                   [GraphQLDescription("The culture.")] string culture = null,
                                                   [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContent(x => x.GetByRoute(preview, route, culture: culture), culture);
        }

        [GraphQLDescription("Gets all the content items at root level.")]
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IEnumerable<IContentGraphType> GetContentAtRoot([Service] IContentRepository contentRepository,
                                                               [GraphQLDescription("The culture.")] string culture = null,
                                                               [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return contentRepository.GetContentList(x => x.GetAtRoot(preview, culture), culture);
        }
    }
}
