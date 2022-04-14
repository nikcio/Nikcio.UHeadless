# Nikcio.UHeadless

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/48f9a00a65284a0d8d7d8660783beb47)](https://www.codacy.com/gh/nikcio/Nikcio.UHeadless/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=nikcio/Nikcio.UHeadless&amp;utm_campaign=Badge_Grade)
[![Maintainability](https://api.codeclimate.com/v1/badges/5452e578a6d25c344e15/maintainability)](https://codeclimate.com/github/nikcio/Nikcio.UHeadless/maintainability)

This repository creates an easy setup solution for making Umbraco headless. It comes with a wide range of extensibility options that can be tailored to your needs.

To get started, add the following to your `Startup.cs`.

## Setup

```CSharp
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
Now your content will be avalible at `/graphql`

To get started try adding some content to the root and run the following query:
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

## Documentation is coming... Hang in there
[Find the docs here](docs/index.md)

## Todo

-   [x] GraphQL Playground
-   [x] Extending types
-   [x] Creating base types
-   [x] Published Content
-   [x] Culture support
-   [x] Metrics
-   [x] Published Media
-   [x] API Tokens (OAUTH) with permissions (for content types and properties)
-   [x] Content
-   [x] Media
-   [x] v2 Refactor
-   [ ] Documentation
-   [ ] Dictionary
-   [ ] Members
-   [ ] Subcription of content
-   [ ] Dashbord in Umbraco?
-   [ ] Data Types
-   [ ] Document Types
-   [ ] Media Types
-   [ ] Member Types