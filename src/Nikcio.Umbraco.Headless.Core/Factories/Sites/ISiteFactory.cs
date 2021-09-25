using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites
{
    public interface ISiteFactory
    {
        ICreateSiteCommandBase CreateSiteCommandBase { get; }
        void SetCreateSiteCommandBase(IPublishedContent publishedContent, string culture);
        ISiteModelBase GetSiteData(IPublishedContent publishedContent, string culture);
    }
}