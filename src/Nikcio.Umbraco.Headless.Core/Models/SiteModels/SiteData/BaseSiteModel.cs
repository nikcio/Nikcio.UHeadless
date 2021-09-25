using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.SiteData
{
    public class BaseSiteModel : ISiteModelBase
    {
        public BaseSiteModel(ICreateSiteCommandBase createSiteCommandBase)
        {
            Content = createSiteCommandBase.PageFactory.GetPageData(createSiteCommandBase);
        }

        public IPageModelBase Content { get; set; }
    }
}
