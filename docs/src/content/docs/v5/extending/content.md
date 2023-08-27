---
title: Extending Content Data Structures in Nikcio.UHeadless
description: Learn how to extend the content model in Nikcio.UHeadless.
---

Nikcio.UHeadless provides flexibility to extend and replace content data structures to accommodate your specific needs. This documentation outlines some examples of how you can extend the content data structures.

## Example 1: Simple Content Model

1. Create your content model by inheriting from `BasicContent`:

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

    public MyContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Content.Queries;

public class MyContentAtRootQuery : ContentAtRootQuery<MyContent>
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
            builder.UseContentQueries();
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

    public MyContentWithMyProperty(CreateContent createContent, IPropertyFactory<MyProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<MyProperty, BasicContentType, BasicContentRedirect>> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}
```

3. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Content.Queries;

public class MyContentAtRootQueryWithMyProperty : ContentAtRootQuery<MyContentWithMyProperty>
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
            builder.UseContentQueries();  
            builder.AddTypeExtension<MyContentAtRootQueryWithMyProperty>();
            return builder;
        },
    },
})
```

5. Open `/graphql` and observe your new model for the `ContentAtRoot` query.

## Example 3: Creating Content Model from Scratch

1. Create your content model by inheriting from `Content<TProperty>`:

```csharp
using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;

public class MyContentFromScratch : Nikcio.UHeadless.Content.Models.Content
{
    public string MyCustomValue { get; set; }

    [GraphQLDescription("Gets the properties of the element.")]
    [UseFiltering]
    public virtual IEnumerable<BasicProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture, Segment, Fallback) : default;

    protected IPropertyFactory<BasicProperty> PropertyFactory { get; }

    public MyContentFromScratch(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory) : base(createContent)
    {
        MyCustomValue = "Custom Value";
        PropertyFactory = propertyFactory;
    }
}
```

2. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Content.Queries;

public class MyContentAtRootQueryWithMyContentFromScratch : ContentAtRootQuery<MyContentFromScratch>
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
            builder.UseContentQueries();  
            builder.AddTypeExtension<MyContentAtRootQueryWithMyContentFromScratch>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `ContentAtRoot` query.

## Example 4: Extended Content Model with public access settings

1. Create your access rule model:

```csharp
using HotChocolate;

[GraphQLDescription("Represents an access rule for the restrict public access settings.")]
public class AccessRuleModel
{
    public AccessRuleModel(string? ruleType, string? ruleValue)
    {
        RuleType = ruleType ?? string.Empty;
        RuleValue = ruleValue ?? string.Empty;
    }

    [GraphQLDescription("Gets the type of protection to grant access to the content item.")]
    public string RuleType { get; set; }
    [GraphQLDescription("Gets the name of who has access to the content item.")]
    public string RuleValue { get; set; }
}
```

2. Create your Permissions model:

```csharp
using System.Collections.Generic;
using HotChocolate;

namespace Examples.Docs.Content.PublicAccessExample;

[GraphQLDescription("Represents a restrict public access settings of a content item.")]
public class PermissionsModel
{
    public PermissionsModel()
    {
        AccessRules = new List<AccessRuleModel>();
    }

    [GraphQLDescription("Gets the url to the login page.")]
    public string? UrlLogin { get; set; }

    [GraphQLDescription("Gets the url to the error page.")]
    public string? UrlNoAccess { get; set; }

    [GraphQLDescription("Gets the access rules for the restrict public access settings.")]
    public List<AccessRuleModel> AccessRules { get; set; }
}
```

3. Create your content model by inheriting from `BasicContent<TProperty, TContentType, TContentRedirect, TContent>`:

```csharp
using HotChocolate;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Extensions;

[GraphQLDescription("Represents an extended content item.")]
public class CustomBasicContent : BasicContent<BasicProperty, BasicContentType, BasicContentRedirect, CustomBasicContent>
{
    private readonly IPublicAccessService _publicAccessService;
    private readonly IContentService _contentService;
    private readonly IUmbracoContextAccessor _context;
    private readonly ILogger<CustomBasicContent> _logger;

    [GraphQLDescription("Gets the restrict public access settings of the content item.")]
    public PermissionsModel? Permissions { get; set; }

    public CustomBasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<CustomBasicContent> contentFactory, IVariationContextAccessor variationContextAccessor, IPublicAccessService publicAccessService, IContentService contentService, IUmbracoContextAccessor context, ILogger<CustomBasicContent> logger) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        _publicAccessService = publicAccessService;
        _contentService = contentService;
        _context = context;
        _logger = logger;

        if (createContent.Content == null)
        {
            _logger.LogWarning("Content is null");
            return;
        }

        IContent? content = _contentService.GetById(createContent.Content.Id);

        if (content == null)
        {
            _logger.LogWarning("Content from content service is null. Id: {contentId}", createContent.Content.Id);
            return;
        }

        PublicAccessEntry? entry = _publicAccessService.GetEntryForContent(content);

        if (entry != null)
        {
            var cache = _context.GetRequiredUmbracoContext();

            if (cache.Content == null)
            {
                _logger.LogWarning("Content cache is null on Umbraco context");
                return;
            }

            IPublishedContent? loginContent = cache.Content.GetById(entry.LoginNodeId);
            IPublishedContent? noAccessContent = cache.Content.GetById(entry.NoAccessNodeId);

            Permissions = new PermissionsModel
            {
                UrlLogin = loginContent?.Url(),
                UrlNoAccess = noAccessContent?.Url()
            };

            foreach (PublicAccessRule rule in entry.Rules)
            {
                Permissions.AccessRules.Add(new AccessRuleModel(rule.RuleType, rule.RuleValue));
            }
        }
    }
}
```

:::note
We are using `BasicContent<TProperty, TContentType, TContentRedirect, TContent>` to specify the `TContent` type parameter which makes sure that properties like `Children` will return the same model.
:::

4. Extend the query where you want the model to be present. In this example, we extend the `ContentAtRoot` query:

```csharp
using Nikcio.UHeadless.Content.Queries;

public class CustomBasicContentContentAtRootQuery : ContentAtRootQuery<CustomBasicContent>
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
            builder.UseContentQueries();  
            builder.AddTypeExtension<CustomBasicContentContentAtRootQuery>();
            return builder;
        },
    },
})
```

4. Open `/graphql` and observe your new model for the `ContentAtRoot` query.

These examples demonstrate different ways to extend content data structures in Nikcio.UHeadless. Choose the method that best suits your requirements and customize the models and queries accordingly.

:::note
Make sure to include the necessary namespaces and dependencies based on your project structure.
:::