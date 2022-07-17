# Create a new property value

If you are using a custom property editor you might need to create your own property value to have your data presented correctly.

## Create the model
```csharp
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;

public class CustomPropertyValue : PropertyValue {

    public string? Name { get; set; }

    public CustomPropertyValue(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
        var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        if (value == null) {
            return;
        }

        Name = (string) value;
    }
}
```

In this example we have a property editor that saves a string as the value.

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
                    propertyMap => propertyMap.AddEditorMapping<CustomPropertyValue>("myCustomPropertyEditorAlias")
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

## Query

Now you can query your editor and you value should now be presented

## Dependency injection

All property values support dependency injection which means you can inject any service you need into the constructor to create properties.
For example:
```csharp
public class CustomPropertyValue : PropertyValue {

    public string Name { get; set; }

    public CustomPropertyValue(CreatePropertyValue createPropertyValue, IContentService contentserivce) : base(createPropertyValue) {
        Name = (string)createPropertyValue.Property.GetValue(createPropertyValue.Culture);
    }
}
```