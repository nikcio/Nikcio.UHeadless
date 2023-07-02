---
title: UHeadless Options
description: Overview of the options in Nikcio.UHeadless.
---

The `UHeadlessOptions` class provides configuration options for the UHeadless package. These options can be used to customize various aspects of UHeadless behavior.

## UHeadlessOptions Properties

| Property                  | Description                                                                             |
|---------------------------|-----------------------------------------------------------------------------------------|
| PropertyServicesOptions   | Options for configuring the property services.                                          |
| TracingOptions            | Options for configuring Apollo tracing.                                                 |
| UHeadlessGraphQLOptions   | Options for configuring UHeadless GraphQL functionality.                                |

## UHeadlessGraphQLOptions Properties

| Property               | Description                                                                                           |
|------------------------|-------------------------------------------------------------------------------------------------------|
| GraphQLExtensions      | Used to configure HotChocolate with any custom configuration                                          |
| PropertyValueTypes     | A collection of the types in the solution that implement the `PropertyValue` interface. This is populated automatically.  |

## TracingOptions Properties

| Property                | Description                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------|
| TracingPreference       | Specifies the preference for enabling tracing in Apollo.                                          |
| TimestampProvider       | ITimestampProvider                                                                                |

## PropertyServicesOptions Properties

| Property                | Description                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------|
| PropertyMapOptions      | Options for configuring the property map.                                                         |

## PropertyMapOptions Properties

| Property                | Description                                                                                       |
|-------------------------|---------------------------------------------------------------------------------------------------|
| PropertyMappings        | A list of custom mappings for properties.                                                         |
| PropertyMap             | The property map used for mapping properties.                                                     |

To configure the UHeadless options, use the `.AddUHeadless()` method and provide an instance of `UHeadlessOptions` with the desired settings.

Example usage:

```csharp
.AddUHeadless(new()
{
    PropertyServicesOptions = new()
    {
        PropertyMapOptions = new()
        {
            PropertyMappings = new List<Action<IPropertyMap>>
            {
                (map) => map.AddEditorMapping<CustomBlockListModel>(Constants.PropertyEditors.Aliases.BlockList),
                (map) => map.AddAliasMapping<CustomMediaPicker>("myContentType", "myPropertyAlias")
            }
        }
    }
})
```

These options allow you to configure property services, Apollo tracing, and UHeadless GraphQL functionality. Customize the options according to your specific requirements.