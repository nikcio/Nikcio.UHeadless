using Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers;
using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Factories
{
    public interface IPageDataFactory
    {
        ICreatePropertyCommandBase CreatePropertyCommandBase { get; }
        void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase);
        IPropertyModelBase GetPropertyData();
        IPropertyModelBase GetPropertyData(ICreatePageCommandBase createPageCommandBase);
    }
}