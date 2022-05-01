# Extend the existing media picker model

To extend an existing models also known as [Basics](basics.md) we need to inherit from the existing model and then register the new model in place of the old model.

## Create the model
```csharp
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;

public class CustomMediaPicker : BasicMediaPicker {

    public string MyCustomProperty { get; set; }

    public CustomMediaPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        MyCustomProperty = "Here's a custom property";
    }
}
```

Here we are creating a custom media picker value and adding the property `MyCustomProperty`.

On some models you can customize the models at differet levels. For example the Picker values allow you to specify the item model used by the picker model.
```csharp
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Models;

public class CustomMediaPicker2 : BasicMediaPicker<BasicMediaPickerItem> {

    public string MyCustomProperty { get; set; }

    public CustomMediaPicker2(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        MyCustomProperty = "Here's a custom property2";
    }
}
```

## Register the model
```csharp
services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddUHeadless(new() {
        PropertyServicesOptions = new() {
            PropertyMapOptions = new() {
                PropertyMappings = new() {
                    map => map.AddEditorMapping<CustomMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker),
                    map => map.AddEditorMapping<CustomMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker3)
                }
            }
        }
    })
    .Build();
```

You need to register the mapping in the PropertyMapOptions. Here you can use the methods:

`AddAliasMapping`
Adds a mapping of a type to a content type alias combined with a property type alias.

`AddEditorMapping`
Adds a mapping of a type to a editor alias.

## Query a media picker

Now you can query a media picker editor and you value should now be presented along with the custom property data.

## Defaults

Most of the Umbraco editors have a default [Basic](basics.md) value set that will be used if no custom property mapping is set.
Find all the defaults under `AddPropertyMapDefaults` in [`PropertyMap`](../../../src/Nikcio.UHeadless/UmbracoElements/Properties/Maps/PropertyMap.cs)

If no basic is found the `BasicPropertyValue` is used instead.

## Dependency injection

All property values support dependency injection which means you can inject any service you need into the constructor to create properties.
For example:
```csharp
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;

public class CustomMediaPicker : BasicMediaPicker {

    public string MyCustomProperty { get; set; }

    public CustomMediaPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory, IContentService contentservice) : base(createPropertyValue, dependencyReflectorFactory) {
        MyCustomProperty = "Here's a custom property";
    }
}
```