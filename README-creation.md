# Nikcio.UHeadless

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=nikcio_Nikcio.UHeadless&metric=alert_status)](https://sonarcloud.io/summary/new_code?id=nikcio_Nikcio.UHeadless)
[![Build UHeadless](https://github.com/nikcio/Nikcio.UHeadless/actions/workflows/build.yml/badge.svg)](https://github.com/nikcio/Nikcio.UHeadless/actions/workflows/build.yml)
![Nuget Downloads](https://img.shields.io/nuget/dt/Nikcio.UHeadless.Creation?color=%230078d7&label=Nuget%20downloads&logo=Nuget)
![Nuget Version](https://img.shields.io/nuget/v/Nikcio.UHeadless.Creation?label=Stable%20version)
![Nuget (with prereleases)](https://img.shields.io/nuget/vpre/Nikcio.UHeadless.Creation?label=Prerelease%20version)

Welcome to Nikcio.UHeadless.Creation, a powerful package that enables you to create custom models for your Umbraco CMS. This package provides an easy-to-setup solution for exposing your data internally in your application or externally to a database, Omnichannel API for something completely different. Nikcio.UHeadless.Creation offers a wide range of extensibility options to tailor your models to your specific needs.

## Compatibility

The Nikcio.UHeadless.Creation package is compatible with the following Umbraco versions:

| Umbraco version      | Supported Versions    |
|----------------------|-----------------------|
| Umbraco 11           | v5.x.x                |
| Umbraco 12           | v5.x.x                |

For more information, please refer to the [Versioning](#versioning) section.

## Setup

### Installation

To install the Nikcio.UHeadless.Creation package, run the following command:

```shell
dotnet add Nikcio.UHeadless.Creation
```

You can also find the package on [NuGet](https://www.nuget.org/packages/Nikcio.UHeadless.Creation).

### Integration

To integrate the package into your project, follow these steps:

1. Open your `Startup.cs` file.
2. Add the following using statement:

   ```csharp
   using Nikcio.UHeadless.Creation.Extensions;
   ```

3. In the `ConfigureServices` method, add the following code:

   ```csharp
   public void ConfigureServices(IServiceCollection services)
   {
       services.AddUmbraco(_env, _config)
           /* Code omitted for clarity */
           .AddUHeadlessCreation()
           /* Code omitted for clarity */
   }
   ```

With these configurations in place, you will be able to begin using the services and models provided by Nikcio.UHeadless.Creation. See the documentation for the next steps.

## Documentation

For detailed documentation and usage instructions, please refer to the [Nikcio.UHeadless.Creation Documentation](https://nikcio.github.io/Nikcio.UHeadless).

## Extending Packages

Nikcio.UHeadless.Creation offers various packages for extending its functionality. The following table lists the available packages and their current status:

| Package Name                      | Status       |
| --------------------------------- | ------------ |
| Nikcio.UHeadless.Creation.Content          | Included*    |
| Nikcio.UHeadless.Creation.Media            | Included*    |
| Nikcio.UHeadless.Creation.ContentTypes     | Included*    |
| Nikcio.UHeadless.Creation.Members          | Available    |
| Nikcio.UHeadless.Creation.Basics           | Preview**    |

\***Included** indicates that the package is included in the Nikcio.UHeadless NuGet package.

\*\***Preview** indicates that the package is available in a preview version.

Please note that if a Nikcio.UHeadless.Creation.\* package is not listed above, it either means that the package is not ready for use or it is a core/base package used in the packages mentioned above.

## Versioning

Nikcio.UHeadless.Creation follows the principles of Semantic Versioning to ensure consistency. The version numbers have the following meaning:

```
vX.Y.Z
```

- X (Major): Indicates a breaking change.
- Y (Minor): Signifies a feature change.
- Z (Patch): Represents bug fixes.

It is important to note that the versioning of Nikcio.UHeadless.Creation does not align with Umbraco's major versions. To manage compatibility, the following versioning tactic has been adopted:

### Versioning Tactic

Each Umbraco LTS (Long-Term Support) version is associated with a corresponding UHeadless LTS version. Any other UHeadless majors that are not marked as LTS will cease to receive support when a new major version is released. This approach allows you, as a developer, to choose the frequency of updates for both UHeadless and Umbraco.

The versioning tracks are as follows:

| Track           | UHeadless Version | Supported Umbraco Version |
| --------------- | ----------------- | ------------------------- |
| LTS             | N/A               | N/A                       |
| Edge            | v5.x.x            | v11.x.x & v12.x.x         |

Please note that LTS versions do not receive new features but will receive bug fixes when a newer major version is available.

## Contributing

We welcome contributions to Nikcio.UHeadless.Creation. Please refer to the [Contributing Guide](CONTRIBUTING.md) for more information on how to get involved.

---

**Sponsor Nikcio.UHeadless.Creation Development**

If you find Nikcio.UHeadless.Creation valuable and would like to support its ongoing development, consider sponsoring the project through [GitHub Sponsors](https://github.com/sponsors/nikcio/). Your sponsorship helps ensure the continued improvement and maintenance of this package. Thank you for your support!