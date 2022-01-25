using Nikcio.UHeadless.Dtos.Content;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories
{
    public interface IPropertyFactory
    {
        void AddProperty(PublishedContentGraphType publishedContentGraphType, IPublishedProperty publishedProperty);
    }
}