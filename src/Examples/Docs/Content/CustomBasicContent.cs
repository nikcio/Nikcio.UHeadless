using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Content.Models;
using Nikcio.UHeadless.Basics.ContentTypes.Models;
using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;
using Nikcio.UHeadless.ContentTypes.Factories;

namespace Examples.Docs.Content {
    public class CustomBasicContent : BasicContent {

        public string MyCustomValue { get; set; }

        public CustomBasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty> contentFactory) : base(createContent, propertyFactory, contentTypeFactory, contentFactory) {
            MyCustomValue = "Custom Value";
        }
    }
}
