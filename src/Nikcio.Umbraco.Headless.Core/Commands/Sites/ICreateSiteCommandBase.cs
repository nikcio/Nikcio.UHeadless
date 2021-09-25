using Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages;
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