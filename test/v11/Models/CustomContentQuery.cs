﻿using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Enums;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Content.Router;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace v11.Models
{
    [ExtendObjectType(typeof(Query))]
    public class CustomContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType>, BasicProperty, BasicContentRedirect>
    {
        [Authorize]
        public override IEnumerable<BasicContent<BasicProperty, BasicContentType>?> GetContentAtRoot([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The culture.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return base.GetContentAtRoot(contentRepository, culture, preview);
        }

        [Authorize]
        public override Task<BasicContent<BasicProperty, BasicContentType>?> GetContentByAbsoluteRoute([Service(ServiceKind.Default)] IContentRouter<BasicContent<BasicProperty, BasicContentType>, BasicProperty, BasicContentRedirect> contentRouter, [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route, [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "", [GraphQLDescription("The culture.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false, [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing)
        {
            return base.GetContentByAbsoluteRoute(contentRouter, route, baseUrl, culture, preview, routeMode);
        }

        [Authorize]
        public override IEnumerable<BasicContent<BasicProperty, BasicContentType>?> GetContentByContentType([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The contentType to fetch.")] string contentType, [GraphQLDescription("The culture.")] string? culture = null)
        {
            return base.GetContentByContentType(contentRepository, contentType, culture);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType>? GetContentByGuid([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The id to fetch.")] Guid id, [GraphQLDescription("The culture to fetch.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return base.GetContentByGuid(contentRepository, id, culture, preview);
        }

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType>? GetContentById([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The id to fetch.")] int id, [GraphQLDescription("The culture to fetch.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return base.GetContentById(contentRepository, id, culture, preview);
        }
    }
}
