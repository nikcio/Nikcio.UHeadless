# Extending the Rich text model in Nikcio.UHeadless

Nikcio.UHeadless provides flexibility to extend and replace the rich text model to accommodate your specific needs. This documentation outlines two examples of how you can extend the model.

## Example 1

1. Create your own rich text model:

```csharp
using Nikcio.UHeadless.Base.Basics.EditorsValues.RichTextEditor.Models;
using Nikcio.UHeadless.Base.Properties.Commands;

public class MyRichText : BasicRichText
{
    public string MyCustomProperty { get; set; }

    public MyRichText(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        MyCustomProperty = "Hello here is a property";
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
                map => map.AddEditorMapping<MyRichText>(Constants.PropertyEditors.Aliases.TinyMce)
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