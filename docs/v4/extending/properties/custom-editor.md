# Adding your custom editor model in Nikcio.UHeadless

Nikcio.UHeadless provides flexibility to add your own models for custom property editors. This documentation outlines one example of how you can create this model.

## Example 1

1. Create your custom editor model:

```csharp
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;

public class MyPropertyValue : PropertyValue
{
    public string? Name { get; set; }

    public MyPropertyValue(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        if (value == null)
        {
            return;
        }

        Name = (string) value;
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
                map => map.AddEditorMapping<MyPropertyValue>("customEditor")
            }
        }
    }
})
```

| Method Name       | Description                                                                    |
|-------------------|--------------------------------------------------------------------------------|
| AddAliasMapping   | Adds a mapping of a type to a content type alias and property type alias.      |
| AddEditorMapping  | Adds a mapping of a type to an editor alias.                                   |

Make sure to replace the appropriate namespaces and class names with your own custom implementations.