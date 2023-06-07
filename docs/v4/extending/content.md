# Extending Content Data Structures in Nikcio.UHeadless

Nikcio.UHeadless provides flexibility to extend and replace content data structures to accommodate your specific needs. This documentation outlines three examples of how you can extend the content data structures.

## Example 1: Simple Content Model Extension

1. Create your own content model by inheriting from `BasicContent`:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

public class MyContent : BasicContent
{
    public string MyCustomValue { get; set; }

    public MyContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent, BasicProperty> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Content.Queries;

public class MyContentAtRootQuery : ContentAtRootQuery<MyContent, BasicProperty>
{
}
```

3. Register the query in Nikcio.UHeadless:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.AddTypeExtension<MyContentAtRootQuery>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `ContentAtRoot` query.

## Example 2: Extended Content Model with Custom Property

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

2. Create your content model by inheriting from `BasicContent<TProperty>`:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

public class MyContentWithMyProperty : BasicContent<MyProperty>
{
    public string MyCustomValue { get; set; }

    public MyContentWithMyProperty(CreateContent createContent, IPropertyFactory<MyProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<MyProperty, BasicContentType, BasicContentRedirect>, MyProperty> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}
```

3. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Content.Queries;

public class MyContentAtRootQueryWithMyProperty : ContentAtRootQuery<MyContentWithMyProperty, MyProperty>
{
}
```

4. Register the query in Nikcio.UHeadless:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.AddTypeExtension<MyContentAtRootQueryWithMyProperty>();
            return builder;
        },
    },
})
```

5. Open `/graphql` and observe your new model for the `ContentAtRoot` query.

## Example 3: Creating Content Model from Scratch

1. Create your own content model by inheriting from `Content<TProperty>`:

```csharp
using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;

public class MyContentFromScratch : Content<BasicProperty>
{
    public string MyCustomValue { get; set; }

    [GraphQLDescription("Gets the properties of the element.")]
    [UseFiltering]
    public virtual IEnumerable<BasicProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture, Segment, Fallback) : default;

    public MyContentFromScratch(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory) : base(createContent, propertyFactory)
    {
        MyCustomValue = "Custom Value";
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Content.Queries;

public class MyContentAtRootQueryWithMyContentFromScratch : ContentAtRootQuery<MyContentFromScratch, BasicProperty>
{
}
```

3. Register the query in Nikcio.UHeadless:

```csharp
.AddUHeadless(new()
{
    UHeadlessGraphQLOptions = new()
    {
        GraphQLExtensions = (IRequestExecutorBuilder builder) =>
        {
            builder.AddTypeExtension<MyContentAtRootQueryWithMyContentFromScratch>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `ContentAtRoot` query.

These examples demonstrate different ways to extend content data structures in Nikcio.UHeadless. Choose the method that best suits your requirements and customize the models and queries accordingly.

Note: Make sure to include the necessary namespaces and dependencies based on your project structure.