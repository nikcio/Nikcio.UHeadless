using System.Collections.Generic;
using Examples.Docs.Properties;
using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Factories;
using Nikcio.UHeadless.Media.Models;

namespace Examples.Docs.Media;

public class MyMedia : BasicMedia
{
    public string MyCustomValue { get; set; }

    public MyMedia(CreateMedia createMedia, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IMediaFactory<BasicMedia> mediaFactory) : base(createMedia, propertyFactory, contentTypeFactory, mediaFactory)
    {
        MyCustomValue = "Custom Value";
    }
}

public class MyMediaWithMyProperty : BasicMedia<MyProperty>
{
    public string MyCustomValue { get; set; }

    public MyMediaWithMyProperty(CreateMedia createMedia, IPropertyFactory<MyProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IMediaFactory<BasicMedia<MyProperty, BasicContentType>> mediaFactory) : base(createMedia, propertyFactory, contentTypeFactory, mediaFactory)
    {
        MyCustomValue = "Custom Value";
    }
}

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