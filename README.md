# Nikcio.UHeadless

[![Codacy Badge](https://app.codacy.com/project/badge/Grade/48f9a00a65284a0d8d7d8660783beb47)](https://www.codacy.com/gh/nikcio/Nikcio.UHeadless/dashboard?utm_source=github.com&amp;utm_medium=referral&amp;utm_content=nikcio/Nikcio.UHeadless&amp;utm_campaign=Badge_Grade)
[![Maintainability](https://api.codeclimate.com/v1/badges/5452e578a6d25c344e15/maintainability)](https://codeclimate.com/github/nikcio/Nikcio.UHeadless/maintainability)
[![Build UHeadless](https://github.com/nikcio/Nikcio.UHeadless/actions/workflows/build.yml/badge.svg)](https://github.com/nikcio/Nikcio.UHeadless/actions/workflows/build.yml)
![Nuget Downloads](https://img.shields.io/nuget/dt/Nikcio.UHeadless?color=%230078d7&label=Nuget%20downloads&logo=Nuget)
![Nuget Version](https://img.shields.io/nuget/v/Nikcio.UHeadless?label=Stable%20version)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Nikcio.UHeadless?label=Prerelease%20version)

This repository creates an easy setup solution for making Umbraco headless. It comes with a wide range of extensibility options that can be tailored to your needs.

## Works on

* Umbraco 9 (v1.x.x & v2.x.x)
* Umbraco 10 (v2.x.x & v3.x.x)

See more under [Versioning](#Versioning)

## Setup

To get started, add the following to your `Startup.cs`.

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

## Documentation
### [Find the docs here](docs/README.md)

## Extending packages

See [How to use a extending package](docs/v3/otherPackages/howToUseAExtendingPackage.md)

| Package name                     | Status       |
| -------------------------------- | ------------ |
| Nikcio.UHeadless.Content         | Included*    |
| Nikcio.UHeadless.Media           | Included*    |
| Nikcio.UHeadless.ContentTypes    | Included*    |
| Nikcio.UHeadless.Members         | Available    |
| Nikcio.UHeadless.DataTypes       | Not started  |
| Nikcio.UHeadless.Dictionary      | Not started  |
| Nikcio.UHeadless.MediaTypes      | Not started  |
| Nikcio.UHeadless.MemberTypes     | Not started  |
| Nikcio.UHeadless.Cache.InMemory  | Researching  |
| Nikcio.UHeadless.Cache.Redis     | Researching  |
| Nikcio.UHeadless.Cache.TextFiles | Researching  |

\***Included** means that the package is included in the Nikcio.UHeadless Nuget package.

\*\***Preview** means that the package is ready in a preview version.

**Note: If a Nikcio.UHeadless.\* package is not found in the list above it's not ready for use or is a core/base package used in the packages above.**

## Versioning
UHeadless following to the best of abillity Semantic Versioning. This means that the version numbers have the following meaning

vX.Y.Z

* X (Major - Breaking change)
* Y (Minor - Feature change)
* Z (Patch - Bug fixes)

This also means that versions doesn't follow Umbracos major versions.
To avoid supporting to many major versions the following versioning tactic has been choosen.

### Versioning tactic

Each Umbraco LTS version will have a accompanying LTS UHeadless version. All other UHeadless majors not marked as LTS will stop support when a new major is released.
In this way you as a developer can choose how often you expect to be updating UHeadless and Umbraco.

The two versioning tracks can be found in the table here:

| Track | UHeadless version | Supported Umbraco version |
|-------|-------------------|---------------------------|
|  LTS  |      v3.x.x       |          v10.x.x          |
|  Edge |      v3.x.x       |          v10.x.x          |
|  Current stable | v3.x.x  |          v10.x.x          |

**Do note that LTS versions will not actively get new featues but will be bugfixed when a newer major is present**

## Contributing

This package is very much open for contribution see the [Contributing Guide](CONTRIBUTING.md)