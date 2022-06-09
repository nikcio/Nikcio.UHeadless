using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Factories;

namespace Examples.Docs.Content {
    public class CustomBasicContent : BasicContent {

        public string MyCustomValue { get; set; }

        public CustomBasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentFactory) : base(createContent, propertyFactory, contentTypeFactory, contentFactory) {
            MyCustomValue = "Custom Value";
        }
    }
}
