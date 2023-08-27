---
title: Extending the Block list model in Nikcio.UHeadless
description: Learn how to extend the block list model in Nikcio.UHeadless.
---

Nikcio.UHeadless provides flexibility to extend and replace the block list model to accommodate your specific needs. This documentation outlines two examples of how you can extend the model.
To extend the block list property and replace it with your own, here are two examples:

## Example 1

1. Create your block list model:

```csharp
using Nikcio.UHeadless.Base.Basics.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Core.Reflection.Factories;

public class MyBlockListModel : BasicBlockListModel
{
    public string MyCustomProperty { get; set; }

    public MyBlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory)
    {
        MyCustomProperty = "Hello I'm Custom!";
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
                map => map.AddEditorMapping<MyBlockListModel>(Constants.PropertyEditors.Aliases.BlockList)
            }
        }
    }
})
```

## Example 2

1. Create your property model by inheriting from `BasicProperty`:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;

public class MyProperty : BasicProperty
{
    public string MyString { get; set; }

    public MyProperty(CreateProperty createProperty, IPropertyValueFactory propertyValueFactory) : base(createProperty, propertyValueFactory)
    {
        MyString = "My string";
    }
}
```

2. Create your block list model:

```csharp
using Examples.Docs.Properties;
using Nikcio.UHeadless.Base.Basics.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Core.Reflection.Factories;

public class MyBlockListModelWithMyProperty : BasicBlockListModel<BasicBlockListItem<MyProperty>>
{
    public string MyCustomProperty { get; set; }

    public MyBlockListModelWithMyProperty(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory)
    {
        MyCustomProperty = "Hello I'm Custom!";
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
                map => map.AddEditorMapping<MyBlockListModelWithMyProperty>(Constants.PropertyEditors.Aliases.BlockList)
            }
        }
    }
})
```

In both examples, you create your block list model by inheriting from the appropriate base class (`BasicBlockListModel` or `BasicBlockListModel<TBlockListItem>`). Then, you register the model in the UHeadless options by adding a property mapping with `AddEditorMapping`. This will replace the default block list model with your custom model.

| Method Name       | Description                                                                    |
|-------------------|--------------------------------------------------------------------------------|
| AddAliasMapping   | Adds a mapping of a type to a content type alias and property type alias.      |
| AddEditorMapping  | Adds a mapping of a type to an editor alias.                                   |

Make sure to replace the appropriate namespaces and class names with your custom implementations.