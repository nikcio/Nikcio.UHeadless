using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Factories
{
    public interface IContentFactory<TContent, TProperty>
            where TContent : IContent<TProperty>
            where TProperty : IProperty
    {
        TContent? CreateContent(IPublishedContent content, string? culture);
    }
}
