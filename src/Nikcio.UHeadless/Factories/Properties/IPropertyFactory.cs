using Nikcio.UHeadless.Models.Dtos.Content;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories.Properties
{
    public interface IPropertyFactory
    {
        void AddProperty(PublishedContentGraphType publishedContentGraphType, IPublishedContent publishedContent, IPublishedProperty publishedProperty, string culture);
        void AddProperty(PublishedElementGraphType publishedContentGraphType, IPublishedContent publishedContent, IPublishedProperty publishedProperty, string culture);
        PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture);
    }
}