---
title: Member Queries
description: Learn how to query members in Nikcio.UHeadless.
---

The Nikcio.UHeadless package provides various member queries that allow you to retrieve member data from Umbraco CMS. These queries are divided into two variations: "Basic" and "Auth" queries.

## Prerequisites

To use the member queries you'll need to install the member package:

```shell
dotnet add Nikcio.UHeadless.Members
```

## Basic Queries

The "Basic" queries do not require authorization and provide unrestricted access to member data. Use the following code example to add basic member queries to the UHeadless options:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.UseMemberQueries(); // Use this from v4.1.0+ (Only add one)
            builder.AddTypeExtension<BasicMembersAllQuery>();
            return builder;
        },
    },
})
```

The following basic member queries are available:

| Query class Name                   | Description                                    |
|------------------------------------|------------------------------------------------|
| BasicFindMembersByDisplayNameQuery | Finds members by display name.                 |
| BasicFindMembersByEmailQuery       | Finds members by email.                        |
| BasicFindMembersByRoleQuery        | Finds members by role.                         |
| BasicFindMembersByUsernameQuery    | Finds members by username.                     |
| BasicMemberByEmailQuery            | Gets a member by email.                        |
| BasicMemberByIdQuery               | Gets a member by ID.                           |
| BasicMemberByKeyQuery              | Gets a member by key.                          |
| BasicMemberByUsernameQuery         | Gets a member by username.                     |
| BasicMembersAllQuery               | Gets all members by filter and/or page index.  |
| BasicMembersByIdQuery              | Gets members by ID.                            |

You can explore these queries and their parameters in the UI provided at `/graphql` when you have added them to the `UHeadlessGraphQLOptions.GraphQLExtensions` like in the example above.

## Auth Queries

The "Auth" queries require authentication when querying member data. "Auth" queries are "Basic" queries that have been overridden and added the `[Authorize]` attribute from `HotChocolate.Authorization`. Use the following code example to add authenticated member queries to the UHeadless options:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.UseMemberQueries(); // Use this from v4.1.0+ (Only add one)
            builder.AddTypeExtension<AuthMemberQuery<TMember, TProperty>>();
            return builder;
        },
    },
})
```

The following authenticated member queries

| Query class Name                   | Description                                    |
|------------------------------------|------------------------------------------------|
| AuthFindMembersByDisplayNameQuery  | Finds members by display name.                 |
| AuthFindMembersByEmailQuery        | Finds members by email.                        |
| AuthFindMembersByRoleQuery         | Finds members by role.                         |
| AuthFindMembersByUsernameQuery     | Finds members by username.                     |
| AuthMemberByEmailQuery             | Gets a member by email.                        |
| AuthMemberByIdQuery                | Gets a member by ID.                           |
| AuthMemberByKeyQuery               | Gets a member by key.                          |
| AuthMemberByUsernameQuery          | Gets a member by username.                     |
| AuthMembersAllQuery                | Gets all members by filter and/or page index.  |
| AuthMembersByIdQuery               | Gets members by ID.                            |

You can explore these queries and their parameters in the UI provided at `/graphql` when you have added them to the `UHeadlessGraphQLOptions.GraphQLExtensions` like in the example above.

## Queries

_Explore the most up-to-date information when the query is registered in your application like in the example in the sections above. Then the query information will be available at `/graphql`_

### FindMembersByDisplayName

Finds members by display name.

Parameters:
- **displayName**: The display name (may be partial).
- **pageIndex**: The page index.
- **pageSize**: The page size.
- **matchType**: Determines how to match a string property value.

### FindMembersByEmail

Finds members by email.

Parameters:
- **email**: The email (may be partial).
- **pageIndex**: The page index.
- **pageSize**: The page size.
- **matchType**: Determines how to match a string property value.

### FindMembersByRole

Finds members by role.

Parameters:
- **roleName**: The role name.
- **usernameToMatch**: The username to match.
- **matchType**: Determines how to match a string property value.

### FindMembersByUsername

Finds members by username.

Parameters:
- **username**: The username (may be partial).
- **pageIndex**: The page index.
- **pageSize**: The page size.
- **matchType**: Determines how to match a string property value.

### MemberByEmail

Gets a member by email.

Parameters:
- **email**: The email to fetch.

### MemberById

Gets a member by ID.

Parameters:
- **id**: The ID to fetch.

### MemberByKey

Gets a member by key.

Parameters:
- **key**: The key to fetch.

### MemberByUsername

Gets a member by username.

Parameters:
- **username**: The username to fetch.

### MembersAll

Gets all members by filter and/or page index.

Parameters:
- **pageIndex**: The current page index.
- **pageSize**: The page size.
- **orderBy**: The field to order by.
- **orderDirection** : The direction to order by.
- **memberTypeAlias**: The member type alias to search for.
- **filter**: The search text filter.

### MembersById

Gets members by ID.

Parameters:
- **ids**: The IDs to fetch.

## Next steps

When creating your GraphQL queries for media, the properties section can be a little difficult to wrap your head around. Therefore, you can find some documentation about how you can query this here.

- [Building your property query](./properties)