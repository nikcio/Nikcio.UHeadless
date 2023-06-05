using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Examples.Docs.Content;

public class CustomBasicContent : BasicContent
{
    public string MyCustomValue { get; set; }

    public CustomBasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent, BasicProperty> contentFactory, IVariationContextAccessor variationContextAccessor) : base(createContent, propertyFactory, contentTypeFactory, contentFactory, variationContextAccessor)
    {
        MyCustomValue = "Custom Value";
    }
}
