using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
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
            CreatePageCommandBase = createPageCommandBase;
            this.pageMapper = pageMapper;
            AddPageMapDefaults();
        }

        private void AddPageMapDefaults()
        {
            if (!pageMapper.ContainsKey(Constants.Constants.Factories.DefaultKey))
            {
                pageMapper.AddMapping<BasePageModel>(Constants.Constants.Factories.DefaultKey);
            }
        }

        public void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase)
        {
            CreatePageCommandBase.SetCreatePageCommandBase(createSiteCommandBase);
        }

        public IPageModelBase GetPageData(ICreateSiteCommandBase createSiteCommandBase)
        {
            SetCreatePageCommandBase(createSiteCommandBase);
            string pageTypeAssemblyQualifiedName;
            if (pageMapper.ContainsKey(CreatePageCommandBase.Content.ContentType.Alias))
            {
                pageTypeAssemblyQualifiedName = pageMapper.GetValue(CreatePageCommandBase.Content.ContentType.Alias);
            }
            else
            {
                pageTypeAssemblyQualifiedName = pageMapper.GetValue(Constants.Constants.Factories.DefaultKey);
            }
            return (IPageModelBase)Activator.CreateInstance(Type.GetType(pageTypeAssemblyQualifiedName), new object[] { CreatePageCommandBase });
        }
    }
}
