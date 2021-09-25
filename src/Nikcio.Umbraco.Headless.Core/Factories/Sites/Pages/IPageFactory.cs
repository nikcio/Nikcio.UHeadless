using Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Models.PageModels;

namespace Nikcio.Umbraco.Headless.Core.Factories.Pages
{
    public interface IPageFactory
    {
        ICreatePageCommandBase CreatePageCommandBase { get; }
        void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase);
        IPageModelBase GetPageData(ICreateSiteCommandBase createSiteCommandBase);
    }
}