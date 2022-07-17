# Extend the existing content model

You can extend the existing [basic](basics.md) content model by adding new or overriding existing properties.

## Create model
```csharp
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Basics.Content.Models;
using Nikcio.UHeadless.Basics.ContentTypes.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Factories;

public class CustomBasicContent : BasicContent {

    public string MyCustomValue { get; set; }

    public CustomBasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty> contentFactory) : base(createContent, propertyFactory, contentTypeFactory, contentFactory) {
        MyCustomValue = "Custom Value";
    }
}
```

## Create custom queries
```csharp
using Nikcio.UHeadless.Basics.Content.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Queries;

public class CustomBasicContentQuery : ContentQuery<CustomBasicContent, BasicProperty, BasicContentRedirect> {
}
```

We need to create a custom query because it's here the content is regitered which content should be used.

## Register new queries

In the `startup.cs` we need to register the new queries. Here we also need to register the unchanged queries because when GraphQL extensions are added they override the default extensions. So if we still would like to use the property and media queries they need to be added here.

```csharp
var graphqlExtensions = (IRequestExecutorBuilder builder) =>
    builder
        .AddTypeExtension<CustomBasicContentQuery>()
        .AddTypeExtension<BasicPropertyQuery>()
        .AddTypeExtension<BasicMediaQuery>();

services.AddUmbraco(_env, _config)
    .AddBackOffice()
    .AddWebsite()
    .AddComposers()
    .AddUHeadless(new() {
        UHeadlessGraphQLOptions = new() {
            GraphQLExtensions = graphQLExtentions
        }
    })
    .Build();
```

## Query

You can now query your new property.