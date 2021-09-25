using Nikcio.Umbraco.Headless.Core.Factories.Pages;
using Nikcio.Umbraco.Headless.Core.Factories.Sites;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Commands.Sites
{
    public interface ICreateSiteCommandBase
    {
        IPublishedContent Content { get; set; }
        string Culture { get; set; }
        IPageFactory PageFactory { get; set; }
        IPublishedValueFallback PublishedValueFallback { get; set; }

        void SetCreateSiteCommandBase(IPublishedContent publishedContent, string culture);
    }
}