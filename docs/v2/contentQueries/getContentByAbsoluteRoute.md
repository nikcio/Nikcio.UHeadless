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
