﻿using System.Collections.Generic;
using Examples.Docs.Properties;
using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Examples.Docs.Content;

public class MyContent : BasicContent
{
    public string MyCustomValue { get; set; }

    public MyContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}

public class MyContentWithMyProperty : BasicContent<MyProperty>
{
    public string MyCustomValue { get; set; }

    public MyContentWithMyProperty(CreateContent createContent, IPropertyFactory<MyProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<MyProperty, BasicContentType, BasicContentRedirect>> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}

public class MyContentFromScratch : Nikcio.UHeadless.Content.Models.Content
{
    public string MyCustomValue { get; set; }

    /// <inheritdoc/>
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