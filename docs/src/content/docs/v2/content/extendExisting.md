---
title: Extend the existing content model
---

You can extend the existing [basic](./basics) content model by adding new or overriding existing properties.

## Create model
```csharp
using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Factories;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Factories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

public class CustomBasicContent : BasicContent {

    public string MyCustomValue { get; set; }

    public CustomBasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentFactory) : base(createContent, propertyFactory, contentTypeFactory, contentFactory) {
        MyCustomValue = "Custom Value";
    }
}
```

## Create custom queries
```csharp
using Nikcio.UHeadless.UmbracoContent.Content.Queries;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

public class CustomBasicContentQuery : ContentQuery<CustomBasicContent, BasicProperty> {
}
```

We need to create a custom query because it's where the content is registered and which content should be used.

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