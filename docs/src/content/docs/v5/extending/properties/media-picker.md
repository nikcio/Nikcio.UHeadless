---
title: Extending the Media Picker model in Nikcio.UHeadless
description: Learn how to extend the media picker model in Nikcio.UHeadless.
---

Nikcio.UHeadless provides flexibility to extend and replace the media picker model to accommodate your specific needs. This documentation outlines two examples of how you can extend the model.
To extend the media picker property and replace it with your own, here are two examples:

## Example 1

1. Create your own media picker model:

```csharp
using Nikcio.UHeadless.Base.Basics.EditorsValues.MediaPicker.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Core.Reflection.Factories;

public class MyMediaPicker : BasicMediaPicker
{
    public string MyCustomProperty { get; set; }

    public MyMediaPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory)
    {
        MyCustomProperty = "Here's a custom property";
    }
}
```

2. Register the model in the UHeadless options:

```csharp
.AddUHeadless(new()
{
    PropertyServicesOptions = new()
    {
        PropertyMapOptions = new()
        {
            PropertyMappings = new()
            {
                map => map.AddEditorMapping<MyMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker)
                map => map.AddEditorMapping<MyMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker3)
                map => map.AddEditorMapping<MyMediaPicker>(Constants.PropertyEditors.Aliases.MultipleMediaPicker)
            }
        }
    }
})
```

## Example 2

1. Create your media picker item by inheriting from `BasicMediaPickerItem`:

```csharp
using Nikcio.UHeadless.Base.Basics.EditorsValues.MediaPicker.Models;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MediaPicker.Commands;

public class MyMediaPickerItem : BasicMediaPickerItem
{
    public int MyProperty { get; set; }

    public MyMediaPickerItem(CreateMediaPickerItem createMediaPickerItem) : base(createMediaPickerItem)
    {
        MyProperty = 0;
    }
}

```

2. Create your own media picker model:

```csharp
using Nikcio.UHeadless.Base.Basics.EditorsValues.MediaPicker.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Core.Reflection.Factories;

public class MyMediaPickerWithMyMediaPickerItem : BasicMediaPicker<MyMediaPickerItem>
{
    public string MyCustomProperty { get; set; }

    public MyMediaPickerWithMyMediaPickerItem(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory)
    {
        MyCustomProperty = "Here's a custom property2";
    }
}
```

3. Register the model in the UHeadless options:

```csharp
.AddUHeadless(new()
{
    PropertyServicesOptions = new()
    {
        PropertyMapOptions = new()
        {
            PropertyMappings = new()
            {
                map => map.AddEditorMapping<MyMediaPickerWithMyMediaPickerItem>(Constants.PropertyEditors.Aliases.MediaPicker)
                map => map.AddEditorMapping<MyMediaPickerWithMyMediaPickerItem>(Constants.PropertyEditors.Aliases.MediaPicker3)
                map => map.AddEditorMapping<MyMediaPickerWithMyMediaPickerItem>(Constants.PropertyEditors.Aliases.MultipleMediaPicker)
            }
        }
    }
})
```

In both examples, you create your own media picker model by inheriting from the appropriate base class (`BasicMediaPicker` or `BasicMediaPicker<TMediaPickerItem>`). Then, you register the model in the UHeadless options by adding a property mapping with `AddEditorMapping`. This will replace the default media picker model with your custom model.

| Method Name       | Description                                                                    |
|-------------------|--------------------------------------------------------------------------------|
| AddAliasMapping   | Adds a mapping of a type to a content type alias and property type alias.      |
| AddEditorMapping  | Adds a mapping of a type to an editor alias.                                   |

Make sure to replace the appropriate namespaces and class names with your custom implementations.