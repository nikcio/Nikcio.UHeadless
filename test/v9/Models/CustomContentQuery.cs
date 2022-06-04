using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using Microsoft.AspNetCore.Http;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Enums;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Repositories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Routing;

namespace v9.Models
{
    [ExtendObjectType(typeof(Query))]
    public class CustomContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType>, BasicProperty>
    {
        [Authorize]
        public override IEnumerable<BasicContent<BasicProperty, BasicContentType>?> GetContentAtRoot([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The culture.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return base.GetContentAtRoot(contentRepository, culture, preview);
        }

        [Authorize]
        public override Task<BasicContent<BasicProperty, BasicContentType>?> GetContentByAbsoluteRoute([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [Service(ServiceKind.Default)] IContentRedirectRepository<BasicContentRedirect> contentRedirectRepository, [Service(ServiceKind.Default)] IPublishedRouter publishedRouter, [Service(ServiceKind.Default)] IHttpContextAccessor httpContextAccessor, [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route, [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "", [GraphQLDescription("The culture.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false, [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing)
        {
            return base.GetContentByAbsoluteRoute(contentRepository, contentRedirectRepository, publishedRouter, httpContextAccessor, route, baseUrl, culture, preview, routeMode);
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

        [Authorize]
        public override BasicContent<BasicProperty, BasicContentType>? GetContentByRoute([Service(ServiceKind.Default)] IContentRepository<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentRepository, [GraphQLDescription("The route to fetch.")] string route, [GraphQLDescription("The culture.")] string? culture = null, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
        {
            return base.GetContentByRoute(contentRepository, route, culture, preview);
        }
    }
}
