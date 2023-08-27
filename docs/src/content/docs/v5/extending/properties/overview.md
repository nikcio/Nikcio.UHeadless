---
title: Nikcio.UHeadless Extension Documentation
description: Get an overview of the Nikcio.UHeadless extension documentation.
---

Welcome to the Nikcio.UHeadless Extension Documentation! Here, you'll find resources to help you extend and customize various features of Nikcio.UHeadless. Please select the topic you want to explore:

- [Block List](./block-list): Learn how to extend and replace the block list property with your custom implementation.
- [Custom Editor](./custom-editor): Discover how to create and integrate your custom editor for property values.
- [Media Picker](./media-picker): Find out how to extend and customize the media picker data.
- [Rich Text](./rich-text): Learn how to extend and replace the rich text editor with your custom implementation.

## Dependency Injection

Dependency injection is supported for all property values, allowing you to inject any required services into the constructor to create properties. Here's an example:

```csharp
public class CustomPropertyValue : PropertyValue
{
    public CustomPropertyValue(CreatePropertyValue createPropertyValue, IContentService contentService) : base(createPropertyValue)
    {
        // Do something with contentService
    }
}
```

In the above example, the `CustomPropertyValue` class demonstrates dependency injection by injecting the `IContentService` into its constructor. This enables you to access the content service within the property value to perform any necessary operations.