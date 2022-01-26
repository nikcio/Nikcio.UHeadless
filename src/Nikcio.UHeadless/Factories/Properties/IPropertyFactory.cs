using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories.Properties
{
    public interface IPropertyFactory
    {
        void AddProperty(PublishedContentGraphType publishedContentGraphType, IPublishedContent publishedContent, IPublishedProperty publishedProperty, string culture);
        void AddProperty(PublishedElementGraphType publishedContentGraphType, IPublishedContent publishedContent, IPublishedProperty publishedProperty, string culture);
    }
}