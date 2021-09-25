using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages.PageData
{
    public interface IPageDataFactory
    {
        ICreatePropertyCommandBase CreatePropertyCommandBase { get; }
        void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase);
        IPropertyModelBase GetPropertyData();
        IPropertyModelBase GetPropertyData(ICreatePageCommandBase createPageCommandBase);
    }
}