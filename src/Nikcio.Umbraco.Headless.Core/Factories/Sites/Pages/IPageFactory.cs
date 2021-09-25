using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages
{
    public interface IPageFactory
    {
        ICreatePageCommandBase CreatePageCommandBase { get; }
        void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase);
        IPageModelBase GetPageData(ICreateSiteCommandBase createSiteCommandBase);
    }
}