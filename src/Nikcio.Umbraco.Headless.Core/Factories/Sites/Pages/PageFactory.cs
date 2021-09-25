using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.SiteData;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages
{
    public class PageFactory : IPageFactory
    {
        public ICreatePageCommandBase CreatePageCommandBase { get; protected set; }

        public PageFactory(ICreatePageCommandBase createPageCommandBase)
        {
            AddPageMapDefaults();
            CreatePageCommandBase = createPageCommandBase;
        }

        private static void AddPageMapDefaults()
        {
            if (!PageMapper.PageMap.ContainsKey(Constants.Constants.Factories.DefaultKey))
            {
                PageMapper.PageMap.Add(Constants.Constants.Factories.DefaultKey, (x) => new BasePageModel(x));
            }
        }

        public void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase)
        {
            CreatePageCommandBase.SetCreatePageCommandBase(createSiteCommandBase);
        }

        public IPageModelBase GetPageData(ICreateSiteCommandBase createSiteCommandBase)
        {
            SetCreatePageCommandBase(createSiteCommandBase);
            return PageMapper.PageMap.ContainsKey(CreatePageCommandBase.Content.ContentType.Alias)
                ? PageMapper.PageMap[CreatePageCommandBase.Content.ContentType.Alias].Invoke(CreatePageCommandBase)
                : PageMapper.PageMap[Constants.Constants.Factories.DefaultKey].Invoke(CreatePageCommandBase);
        }
    }
}
