---
title: Getting Started with Nikcio.UHeadless
description: Learn how to get started with Nikcio.UHeadless.
---

This guide will walk you through the process of integrating Nikcio.UHeadless into your Umbraco solution. By following these steps, you'll be able to create a headless GraphQL interface for your Umbraco CMS.

## Installation

To get started, follow the steps below:

### Step 1: Install the package

Install the Nikcio.UHeadless package using the following command:

```shell
dotnet add Nikcio.UHeadless
```

### Step 2: Add the extensions to the `Startup.cs` file

In your `Startup.cs` file, add the necessary extensions by following the code snippet below:

```csharp
using Nikcio.UHeadless.Extensions;

public void ConfigureServices(IServiceCollection services)
{
    services.AddUmbraco(_env, _config)
        /* Code omitted for clarity */
        .AddUHeadless()
        /* Code omitted for clarity */
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    /* Code omitted for clarity */

    app.UseUHeadlessGraphQLEndpoint();

    app.UseUmbraco();
    /* etc... */
}
```

The `.AddUHeadless()` method adds the services needed for Nikcio.UHeadless to run, while `app.UseUHeadlessGraphQLEndpoint()` adds the endpoint from where you interact with the graphQL interface. These extensions provide a range of options that can be customized. To learn more about available options, refer to the [UHeadless options](../reference/options) and [UHeadless endpoint options](../reference/endpoint-options) documentation.

### Step 3: Find the GraphQL endpoint

By default, the GraphQL endpoint can be accessed at `/graphql` in your application.

### Step 4: Make your first query

To make a query, use the "create document" button in your GraphQL client and paste the following query:

```graphql
{
  contentAtRoot {
    nodes {
      id
      name
    }
  }
}
```

This query fetches all content at the root and retrieves the ID and names of the content nodes.

Congratulations! You have successfully integrated Nikcio.UHeadless into your Umbraco solution. 

## Adding a more queries

To add a more queries to Nikcio.UHeadless, you can include the following code in your `startup.cs` file:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.AddTypeExtension<BasicContentAllQuery>();
            return builder;
        },
    },
})
```

This example demonstrates how to add the `BasicContentAllQuery` query to Nikcio.UHeadless. By including this code, you will enable the ability to query all content items like the example below:

```graphql
{
  contentAll {
    nodes {
      id
      name
    }
  }
}
```

**Do note that adding the code above will override the defaults and removes the `contentAtRoot` query. To use the `contentAtRoot` query the `BasicContentAtRootQuery` will need to be added to the options.**

To explore the available queries and how to use them, refer to the following documentation:

- [Learn how to query properties](../querying/properties)
- [Querying Content](../querying/content)
- [Querying Media](../querying/media)
- [Querying Members](../querying/members)

## Next steps

- [Extending Nikcio.UHeadless](../extend-uheadless)
- [Security Considerations](../security)

If you have any questions or need further assistance, don't hesitate to reach out to us. Happy coding with Nikcio.UHeadless