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

If you want to use the [Skybrud.Umbraco.Redirects](https://github.com/skybrud/Skybrud.Umbraco.Redirects) package for redirects in your Umbraco installation you will need to extend the GetContentByAbsoluteRoute a bit. See an example here: https://gist.github.com/nikcio/695a536ea5e0e5ccc6594a0106caac09

This will fill out the Redirects property in the same way the default implementation propagates out the redirects property.