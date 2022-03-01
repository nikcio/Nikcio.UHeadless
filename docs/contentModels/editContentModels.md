# How to edit content models (Need version 1.1.0+)

In this example we are going to add a string to the existing content model.

To start we will create our custom content model. This needs to inherit from `ContentGraphType<T>` to include the default setup that the package supplies.
**Note:** It's also possible to create your own model from scratch by inheriting from `IContentGraphTypeBase<T>` but this is out of scope of this example.

```csharp
public class CustomContentGraphType<TPropertyGraphType> : ContentGraphType<TPropertyGraphType>
    where TPropertyGraphType : IPropertyGraphTypeBase
{
    public string MyCustomString => "Custom string";
}
```

Then we need to create our custom query model using the new `CustomContentGraphType<TPropertyGraphType>`.

```csharp
[ExtendObjectType(typeof(Query))]
    public class CustomContentQuery : ContentQueryBase<CustomContentGraphType<PropertyGraphType>, PropertyGraphType>
{

}
```

It's here also possible to create custom queries and supply a custom property model the same way as the `CustomContentGraphType<TPropertyGraphType>`. Then you would switch the `PropertyGraphType` model with your custom property model.

**Note:** The property model is used for all properties and will therefore be used on all properties.

Lastly to make the new content model work we need to tell UHeadless to use our quries instead of the defaults like so:

```csharp
var graphQLExtensions = new List<Func<IRequestExecutorBuilder, IRequestExecutorBuilder>>
    { (builder) =>
        builder
            .AddTypeExtension<CustomContentQuery>()
            .AddTypeExtension<PropertyQuery>()
    };

services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddUHeadless(useSecuity: true, graphQLExtensions: graphQLExtensions)
    .Build();
```

Here it's important to add all the default queries to maintain all the functionallity from the default settings. Hence:

```csharp
    .AddTypeExtension<PropertyQuery>()
```

It's also possible to add your own GraphQL extensions here.