using Nikcio.UHeadless.Models.Dtos.Propreties;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Factories.Properties
{
    public interface IPropertyFactory
    {
        PublishedPropertyGraphType GetPropertyGraphType(IPublishedProperty property, IPublishedContent publishedContent, string culture);
    }
}