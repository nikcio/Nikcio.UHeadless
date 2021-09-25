using Nikcio.Umbraco.Headless.Core.Factories.Pages;
using Nikcio.Umbraco.Headless.Core.Factories.Sites;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Commands.Sites
{
    public class CreateSiteCommandBase : ICreateSiteCommandBase
    {
        public IPublishedContent Content { get; set; }
        public string Culture { get; set; }
        public IPageFactory PageFactory { get; set; }
        public IPublishedValueFallback PublishedValueFallback { get; set; }

        public CreateSiteCommandBase(IPageFactory pageFactory, string culture = null, IPublishedContent content = null, IPublishedValueFallback publishedValueFallback = null)
        {
            PageFactory = pageFactory;
            Content = content;
            Culture = culture;
            PublishedValueFallback = publishedValueFallback;
        }

        public void SetCreateSiteCommandBase(IPublishedContent publishedContent, string culture)
        {
            Content = publishedContent;
            Culture = culture;
        }
    }
}
