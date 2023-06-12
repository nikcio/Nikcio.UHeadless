using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Enums;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Content.Router;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default query implementation of the ContentByAbsoulteRoute query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthContentByAbsoluteRouteQuery : ContentByAbsoluteRouteQuery<BasicContent, BasicContentRedirect>
{
    /// <inheritdoc />
    [Authorize]
    public override Task<BasicContent?> ContentByAbsoluteRoute(
        [Service] IContentRouter<BasicContent, BasicContentRedirect> contentRouter,
        [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route,
        [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "",
        [GraphQLDescription("The culture.")] string? culture = null,
        [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
        [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing,
        [GraphQLDescription("The property variation segment")] string? segment = null,
        [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return base.ContentByAbsoluteRoute(contentRouter, route, baseUrl, culture, preview, routeMode, segment, fallback);
    }
}
