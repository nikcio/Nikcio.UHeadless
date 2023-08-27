---
title: Extending Media Data Structures in Nikcio.UHeadless
description: Learn how to extend the media model in Nikcio.UHeadless.
---

Nikcio.UHeadless provides flexibility to extend and replace media data structures to accommodate your specific needs. This documentation outlines three examples of how you can extend the media data structures.

## Example 1: Simple Media Model

1. Create your own media model by inheriting from `BasicMedia`:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Factories;

public class MyMedia : BasicMedia
{
    public string MyCustomValue { get; set; }

    public MyMedia(CreateMedia createMedia, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IMediaFactory<BasicMedia> mediaFactory) : base(createMedia, propertyFactory, contentTypeFactory, mediaFactory)
    {
        MyCustomValue = "Custom Value";
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `MediaAtRoot` query:

```csharp
using Nikcio.UHeadless.Media.Queries;

public class MyMediaAtRootQuery : MediaAtRootQuery<MyMedia>
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
            builder.UseMediaQueries();  
            builder.AddTypeExtension<MyMediaAtRootQuery>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `MediaAtRoot` query.

## Example 2: Extended Media Model with Custom Property

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

2. Create your media model by inheriting from `BasicMedia<TProperty>`:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Factories;

public class MyMediaWithMyProperty : BasicMedia<MyProperty>
{
    public string MyCustomValue { get; set; }

    public MyMediaWithMyProperty(CreateMedia createMedia, IPropertyFactory<MyProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IMediaFactory<BasicMedia<MyProperty, BasicContentType>> mediaFactory) : base(createMedia, propertyFactory, contentTypeFactory, mediaFactory)
    {
        MyCustomValue = "Custom Value";
    }
}
```

3. Extend the query where you want the model to be present. In this example, we extend the `MediaAtRoot` query:

```csharp
using Nikcio.UHeadless.Media.Queries;

public class MyMediaAtRootQueryWithMyProperty : MediaAtRootQuery<MyMediaWithMyProperty>
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
            builder.UseMediaQueries();  
            builder.AddTypeExtension<MyMediaAtRootQueryWithMyProperty>();
            return builder;
        },
    },
})
```

5. Open `/graphql` and observe your new model for the `MediaAtRoot` query.

## Example 3: Creating Media Model from Scratch

1. Create your own media model by inheriting from `Media<TProperty>`:

```csharp
using System.Collections.Generic;
using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Models;

public class MyMediaFromScratch : Nikcio.UHeadless.Media.Models.Media
{
    public string MyCustomValue { get; set; }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the properties of the element.")]
    [UseFiltering]
    public virtual IEnumerable<BasicProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture, Segment, Fallback) : default;

    protected virtual IPropertyFactory<BasicProperty> PropertyFactory { get; }

    public MyMediaFromScratch(CreateMedia createMedia, IPropertyFactory<BasicProperty> propertyFactory) : base(createMedia)
    {
        MyCustomValue = "Custom Value";
        PropertyFactory = propertyFactory;
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `MediaAtRoot` query:

```csharp
using Nikcio.UHeadless.Media.Queries;

public class MyMediaAtRootQueryWithMyMediaFromScratch : MediaAtRootQuery<MyMediaFromScratch>
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
            builder.UseMediaQueries();  
            builder.AddTypeExtension<MyMediaAtRootQueryWithMyMediaFromScratch>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `MediaAtRoot` query.

These examples demonstrate different ways to extend media data structures in Nikcio.UHeadless. Choose the method that best suits your requirements and customize the models and queries accordingly.

Note: Make sure to include the necessary namespaces and dependencies based on your project structure.