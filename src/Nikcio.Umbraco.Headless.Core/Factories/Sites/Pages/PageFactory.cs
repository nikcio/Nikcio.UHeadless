using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.SiteData;
using System;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages
{
    public class PageFactory : IPageFactory
    {
        private readonly IPageMapper pageMapper;

        public ICreatePageCommandBase CreatePageCommandBase { get; protected set; }

        public PageFactory(ICreatePageCommandBase createPageCommandBase, IPageMapper pageMapper)
        {
            AddPageMapDefaults();
            CreatePageCommandBase = createPageCommandBase;
            this.pageMapper = pageMapper;
        }

        private void AddPageMapDefaults()
        {
            if (!pageMapper.ContainsKey(Constants.Constants.Factories.DefaultKey))
            {
                pageMapper.AddMapping(Constants.Constants.Factories.DefaultKey, typeof(BasePageModel));
            }
        }

        public void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase)
        {
            CreatePageCommandBase.SetCreatePageCommandBase(createSiteCommandBase);
        }

        public IPageModelBase GetPageData(ICreateSiteCommandBase createSiteCommandBase)
        {
            SetCreatePageCommandBase(createSiteCommandBase);
            return (IPageModelBase)(pageMapper.ContainsKey(CreatePageCommandBase.Content.ContentType.Alias)
                ? Activator.CreateInstance(pageMapper.GetValue(CreatePageCommandBase.Content.ContentType.Alias))
                : Activator.CreateInstance(pageMapper.GetValue(Constants.Constants.Factories.DefaultKey)));
        }
    }
}
