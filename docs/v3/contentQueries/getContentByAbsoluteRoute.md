# GetContentByAbsoluteRoute

The GetContentByAbsoluteRoute is used for getting content by routes.
This query supports Umbracos built-in redirects and querying on specific domains allowing multisite hosting in Umbraco.

## Parameters

### Route
The `route` parameter is the path of the page you're trying to get. For example `/en/frontpage/` is a route.

### Base url
The `baseUrl` parameter is the base url of your site. This is the same as the domain set in Umbraco under `Culture and hostnames`

Examples:
```
https://localhost:4000
```

```
https://localhost:4000/en
```

```
https://mysite.com
```


### Culture
This is the culture used for fetching your properties. This is only relevant if you use variants.

### Preview
Should the query include unpublished items.

This only works if you hit the caching layer. See RouteMode below for more information.


### Route mode
The route mode parameter tells UHeadless how to fetch the content. 
To fetch preview values you need to have one of the cache rules.

The following options are avalible:

```
CACHE_ONLY
```
Cache only will only look in the content cache for the url

```
ROUTING
```
Routing will use routing to determine a route. This will also show redirects

```
ROUTING_OR_Cache
```
Routing or cache will first use routing to find content and then use the cache if none is found. This also shows redirects

```
CACHE_OR_ROUTING
```
Cache or routing will first use the content cache to find content and then use routing. This will only find redirects if no content is found in the content cache


## Redirect information

The redirect information can be accessed from the new `Redirect` property on the `BasicContent` model. If you have a custom model that doesn't inherit from `BasicContent` see below.

The redirects information will be the only information returned if a redirect is found. The rest will be null. It's recommeded to have your frontend load the content with the redirect url to get the content.

### Redirect recommended flow

1. Frontend loads localhost/redirect

2. UHeadless returns a redirect for the page to localhost/mypage

3. Frontend loads localhost/mypage

4. UHeadless returns the content for the localhost/mypage content node

## Adding redirect information to a custom model

**This is only needed if you don't inherit from `BasicContent`.**

Add a property with the name `Redirect` and give the type of the property a model that inherits from `ContentRedirect`.

Example:
```csharp
[GraphQLDescription("Gets the redirect information.")]
public BasicContentRedirect? Redirect { get; set; }
```

## Redirects with Skybrud.Umbraco.Redirects?

If you want to use the [Skybrud.Umbraco.Redirects](https://github.com/skybrud/Skybrud.Umbraco.Redirects) package for redirects in your Umbraco installation you will need to extend the GetContentByAbsoluteRoute a bit. See an example here:

```csharp
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Skybrud.Umbraco.Redirects.Services;
using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Enums;
using Nikcio.UHeadless.Content.Router;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace MyProject;

[ExtendObjectType(typeof(Query))]
public class CustomContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty, BasicContentRedirect>
{
    private readonly IRedirectsService _redirectsService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CustomContentQuery(
        IRedirectsService redirectsService,
        IHttpContextAccessor httpContextAccessor)
    {
        _redirectsService = redirectsService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async override Task<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>?> GetContentByAbsoluteRoute(
        [Service] IContentRouter<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty, BasicContentRedirect> contentRouter,
        [GraphQLDescription("The route to fetch. Example '/da/frontpage/'.")] string route,
        [GraphQLDescription("The base url for the request. Example: 'https://localhost:4000'. Default is the current domain")] string baseUrl = "",
        [GraphQLDescription("The culture.")] string? culture = null,
        [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
        [GraphQLDescription("Modes for requesting by route")] RouteMode routeMode = RouteMode.Routing)
    {
        var result = await base.GetContentByAbsoluteRoute(contentRouter, route, baseUrl, culture, preview, routeMode);

        if (result != null)
        {
            return result;
        }
        else
        {
            if (_httpContextAccessor == null || _httpContextAccessor.HttpContext == null)
            {
                throw new NullReferenceException("HttpContext could not be found");
            }

            if (string.IsNullOrWhiteSpace(baseUrl))
            {
                baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host.Host}";
            }

            var requestUri = new Uri($"{baseUrl}{route}");
            var skybrudRedirect = _redirectsService.GetRedirectByUri(requestUri);
            if (skybrudRedirect != null)
            {
                var contentRedirectRepository = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContentRedirectRepository<BasicContentRedirect>>();
                var contentRepository = _httpContextAccessor.HttpContext.RequestServices.GetRequiredService<IContentRepository<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty>>();

                var redirect = contentRedirectRepository.GetContentRedirect(new CreateContentRedirect(skybrudRedirect.Destination.FullUrl, skybrudRedirect.IsPermanent));
                var emptyContent = contentRepository.GetConvertedContent(null, null);

                if (emptyContent == null)
                {
                    return default;
                }
                else
                {
                    var redirectProperty = emptyContent.GetType().GetProperty(nameof(BasicContent.Redirect), typeof(BasicContentRedirect));
                    if (redirectProperty == null)
                    {
                        return default;
                    }
                    redirectProperty.SetValue(emptyContent, redirect);
                    return emptyContent;
                }
            }
        }

        return default;
    }
}
```

This will fill out the Redirects property in the same way the default implementation propagates out the redirects property.

**Note the code above will only work when the / at the end of the baseUrl and the start of the route don't overlap and make a //. Therefore, make sure to not include a slash at the end of your baseUrl.**

(Credit: Thanks to @karlmacklin for helping out with the example above.)