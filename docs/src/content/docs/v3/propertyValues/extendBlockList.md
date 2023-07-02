---
title: Extend the existing block list model
description: Learn how to extend the block list model in Nikcio.UHeadless.
---

To extend existing models also known as [Basics](./basics) we need to inherit from the existing model and then register the new model in place of the old model.

## Create the model
```csharp
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;

public class CustomBlockListModel : BasicBlockListModel<BasicBlockListItem<BasicProperty>> {

    public string MyCustomProperty { get; set; }

    public CustomBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        MyCustomProperty = "Hello I'm Custom!";
    }
}
```


Here we are creating a custom block list model value and adding the property `MyCustomProperty`. We also reuse the `BasicBlockListItem` and `BasicProperty` model. These can also be overridden with custom classes and used in this model. (Note: If you make a custom `BasicBlockListItem` or `BasicProperty` these models can be used directly in the `CustomBlockListModel` without being registered elsewhere.)

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
                    map => map.AddEditorMapping<CustomBlockListModel>(Constants.PropertyEditors.Aliases.BlockList)
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

## Query a block list

Now you can query a block list editor and your value should now be presented along with the custom property data.

## Defaults

Most of the Umbraco editors have a default [Basic](./basics) value set that will be used if no custom property mapping is set.
Find all the defaults under `AddPropertyMapDefaults` in `PropertyMapExtensions`

If no basic is found the `BasicPropertyValue` is used instead.

## Dependency injection

All property values support dependency injection which means you can inject any service you need into the constructor to create properties.
For example:
```csharp
public class CustomBlockListModel : BasicBlockListModel<BasicBlockListItem<BasicProperty>> {

    public string MyCustomProperty { get; set; }

    public CustomBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory, IContentService contentservice) : base(createPropertyValue, dependencyReflectorFactory) {
        MyCustomProperty = "Hello I'm Custom!";
    }
}
```