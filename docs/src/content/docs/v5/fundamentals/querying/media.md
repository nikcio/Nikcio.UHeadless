---
title: Media Queries
description: Learn how to query media in Nikcio.UHeadless.
---

The Nikcio.UHeadless package provides various media queries that allow you to retrieve media items in different ways from Umbraco CMS. These queries are divided into two variations: "Basic" and "Auth" queries.

## Basic Queries

The "Basic" queries do not require authorization and provide unrestricted access to CMS data. Use the following code example to add a basic media query to the UHeadless options:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.UseMediaQueries();  
            builder.AddTypeExtension<BasicMediaByContentTypeQuery>();
            return builder;
        },
    },
})
```

**Do note that adding the code above will override the defaults and remove the `contentAtRoot` query. To use the `contentAtRoot` query, you need to add the `BasicContentAtRootQuery` to the options.**

The following basic media queries are available:

| Query class Name                | Description                                |
|---------------------------------|--------------------------------------------|
| BasicMediaAtRootQuery           | Gets all the media items at the root level.|
| BasicMediaByContentTypeQuery    | Gets all the media items by content type.  |
| BasicMediaByGuidQuery           | Gets a media item by GUID.                 |
| BasicMediaByIdQuery             | Gets a media item by ID.                   |

You can explore these queries and their parameters in the UI provided at `/graphql` when you have added them to the `UHeadlessGraphQLOptions.GraphQLExtensions` like in the example above.

## Auth Queries

The "Auth" queries require authentication when querying data. "Auth" queries are "Basic" queries that have been overridden and added the `[Authorize]` attribute from `using HotChocolate.Authorization`. Use the following code example to add an authenticated media query to the UHeadless options:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.UseMediaQueries();  
            builder.AddTypeExtension<AuthMediaByContentTypeQuery>();
            return builder;
        },
    },
})
```

**Do note that adding the code above will override the defaults and remove the `contentAtRoot` query. To use the `contentAtRoot` query, you need to add the `BasicContentAtRootQuery` to the options.**

The following authenticated media queries are available:

| Query class Name              | Description                                  |
|-------------------------------|----------------------------------------------|
| AuthMediaAtRootQuery          | Gets all the media items at the root level.  |
| AuthMediaByContentTypeQuery   | Gets all the media items by content type.    |
| AuthMediaByGuidQuery          | Gets a media item by GUID.                   |
| AuthMediaByIdQuery            | Gets a media item by ID.                     |

You can explore these queries and their parameters in the UI provided at `/graphql` when you have added them to the `UHeadlessGraphQLOptions.GraphQLExtensions` like in the example above.

## Queries

_Explore the most up-to-date information when the query is registered in your application like in the example in the sections above. Then the query information will be available at `/graphql`_

### MediaAtRoot

Gets all the media items at the root level.

Parameters:

- **preview**: Fetch preview values. Preview will show unpublished items.

### MediaByContentType

Gets all the media items by content type.

Parameters:

- **contentType**: The contentType to fetch.

### MediaByGuid

Gets a media item by GUID.

Parameters:

- **id**: The ID to fetch.
- **preview**: Fetch preview values. Preview will show unpublished items.

### MediaById

Gets a media item by ID.

Parameters:

- **id**: The ID to fetch.
- **preview**: Fetch preview values. Preview will show unpublished items.

## Next steps

When creating your GraphQL queries for media, the properties section can be a little difficult to wrap your head around. Therefore, you can find some documentation about how you can query this here.

- [Building your property query](./properties)