using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Models.PageModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models
{
    public class BaseSiteModel : ISiteModelBase
    {
        public BaseSiteModel(ICreateSiteCommandBase createSiteCommandBase)
        {
            createSiteCommandBase.PageFactory.SetCreatePageCommandBase(createSiteCommandBase);
            Content = createSiteCommandBase.PageFactory.GetPageData();
        }

        public IPageModelBase Content { get; set; }
    }
}
