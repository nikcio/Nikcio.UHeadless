using Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers;
using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages
{
    public class CreatePageCommandBase : ICreatePageCommandBase
    {
        public CreatePageCommandBase(IPageDataFactory pageDataFactory, IPublishedContent content = null, IPublishedValueFallback publishedValueFallback = null, string culture = null)
        {
            Content = content;
            PublishedValueFallback = publishedValueFallback;
            Culture = culture;
            PageDataFactory = pageDataFactory;
        }

        public IPublishedContent Content { get; set; }
        public IPublishedValueFallback PublishedValueFallback { get; set; }
        public string Culture { get; set; }
        public IPageDataFactory PageDataFactory { get; set; }

        public void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase)
        {
            Content = createSiteCommandBase.Content;
            Culture = createSiteCommandBase.Culture;
            PublishedValueFallback = createSiteCommandBase.PublishedValueFallback;
        }
    }
}
