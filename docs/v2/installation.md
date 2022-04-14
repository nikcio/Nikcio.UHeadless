# Installation

### Install the package:

```
dotnet add Nikcio.UHeadless
```

### Add the extensions to the `startup.cs` file:

```
using Nikcio.UHeadless.Extensions;

public void ConfigureServices(IServiceCollection services)
        {
            services.AddUmbraco(_env, _config)
                /* Code obmitted for clarity */
                .AddUHeadless()
                /* Code obmitted for clarity */
        }

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
    /* Code obmitted for clarity */

    app.UseUHeadlessGraphQLEndpoint();

    app.UseUmbraco()
    /* etc... */
}
```

`.AddUHeadless()` Adds the services needed for UHeadless to run.
`app.UseUHeadlessGraphQLEndpoint();` Adds the endpoint details needed for UHeadless to run.
Both extensions feature a range of options that can be set for the package. (See more at [UHeadless options](options.md))

### Find the endpoint

By default the GraphQL endpoint will be found at `/graphql`.

### Make your first query

To make a query use the `create document` button and paste the following:

```graphql
{
  contentAtRoot {
    nodes {
      id,
      name
    }
  }
}
```

This will fetch all content at root and get the id and names of the content.