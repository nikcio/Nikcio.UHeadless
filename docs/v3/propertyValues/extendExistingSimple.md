# Extend an existing property value

To extend an existing models also known as [Basics](basics.md) we need to inherit from the existing model and then register the new model in place of the old model.

## Create the model
```csharp
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.RichTextEditor.Models;

public class CustomRichText : BasicRichText {

    public string MyCustomProperty { get; set; }

    public CustomRichText(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
        MyCustomProperty = "Hello here is a property";
    }
}
```

Here we are creating a custom Rich text value and adding the property `MyCustomProperty`.

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
                    propertyMap => propertyMap.AddEditorMapping<CustomRichText>(Constants.PropertyEditors.Aliases.TinyMce)
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

## Query a rich text

Now you can query a rich text editor and you value should now be presented along with the other property data.

## Defaults

Most of the Umbraco editors have a default [Basic](basics.md) value set that will be used if no custom property mapping is set.
Find all the defaults under `AddPropertyMapDefaults` in [`PropertyMapExtensions`](../../../src/Nikcio.UHeadless.Basics/Properties/Maps/Extensions/PropertyMapExtensions.cs)

If no basic is found the `BasicPropertyValue` is used instead.

## Dependency injection

All property values support dependency injection which means you can inject any service you need into the constructor to create properties.
For example:
```csharp
public class CustomRichText : BasicRichText {

    public string MyCustomProperty { get; set; }

    public CustomRichText(CreatePropertyValue createPropertyValue, IContentService contentservice) : base(createPropertyValue) {
        MyCustomProperty = "Hello here is a property";
    }
}
```