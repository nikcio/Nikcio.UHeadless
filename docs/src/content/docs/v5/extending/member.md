---
title: Extending Member Data Structures in Nikcio.UHeadless
description: Learn how to extend the member model in Nikcio.UHeadless.
---

Nikcio.UHeadless provides flexibility to extend and replace member data structures to accommodate your specific needs. This documentation outlines three examples of how you can extend the member data structures.

## Example 1: Simple Member Model

1. Create your own member model by inheriting from `BasicMember`:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Commands;

public class MyMember : BasicMember
{
    public string MyCustomValue { get; set; }

    public MyMember(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory)
    {
        MyCustomValue = "Custom Value";
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `MembersAll` query:

```csharp
using Nikcio.UHeadless.Members.Queries;

public class MyMembersAllQuery : MembersAllQuery<MyMember>
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
            builder.UseMemberQueries();  
            builder.AddTypeExtension<MyMembersAllQuery>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `MembersAll` query.

## Example 2: Extended Member Model with Custom Property

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

2. Create your member model by inheriting from `BasicMember<TProperty>`:

```csharp
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Commands;

public class MyMemberWithMyProperty : BasicMember<MyProperty>
{
    public string MyCustomValue { get; set; }

    public MyMemberWithMyProperty(CreateMember createMember, IPropertyFactory<MyProperty> propertyFactory) : base(createMember, propertyFactory)
    {
        MyCustomValue = "Custom Value";
    }
}
```

3. Extend the query where you want the model to be present. In this example, we extend the `MembersAll` query:

```csharp
using Nikcio.UHeadless.Members.Queries;

public class MyMembersAllQueryWithMyProperty : MembersAllQuery<MyMemberWithMyProperty>
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
            builder.UseMemberQueries();  
            builder.AddTypeExtension<MyMembersAllQueryWithMyProperty>();
            return builder;
        },
    },
})
```

5. Open `/graphql` and observe your new model for the `MembersAll` query.

## Example 3: Creating Member Model from Scratch

1. Create your own member model by inheriting from `Member<TProperty>`:

```csharp
using System.Collections.Generic;
using HotChocolate.Data;
using HotChocolate;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;

public class MyMemberFromScratch : Member
{
    public string MyCustomValue { get; set; }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the properties of the element.")]
    [UseFiltering]
    public virtual IEnumerable<BasicProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture, Segment, Fallback) : default;

    protected virtual IPropertyFactory<BasicProperty> PropertyFactory { get; }

    public MyMemberFromScratch(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember)
    {
        MyCustomValue = "Custom Value";
        PropertyFactory = propertyFactory;
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `MembersAll` query:

```csharp
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Members.Queries;

public class MyMembersAllQueryWithMyMemberFromScratch : MembersAllQuery<MyMemberFromScratch>
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
            builder.UseMemberQueries();  
            builder.AddTypeExtension<MyMembersAllQueryWithMyMemberFromScratch>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `MembersAll` query.

These examples demonstrate different ways to extend member data structures in Nikcio.UHeadless. Choose the method that best suits your requirements and customize the models and queries accordingly.

Note: Make sure to include the necessary namespaces and dependencies based on your project structure.