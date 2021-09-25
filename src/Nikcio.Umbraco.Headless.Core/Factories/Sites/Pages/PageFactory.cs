using Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Models;
using Nikcio.Umbraco.Headless.Core.Models.PageModels;

namespace Nikcio.Umbraco.Headless.Core.Factories.Pages
{
    public class PageFactory : IPageFactory
    {
        public ICreatePageCommandBase CreatePageCommandBase { get; protected set; }

        public PageFactory(ICreatePageCommandBase createPageCommandBase)
        {
            AddPageMapDefaults();
            CreatePageCommandBase = createPageCommandBase;
        }

        private void AddPageMapDefaults()
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

        public IPageModelBase GetPageData()
        {
            return PageMapper.PageMap.ContainsKey(CreatePageCommandBase.Content.ContentType.Alias)
                ? PageMapper.PageMap[CreatePageCommandBase.Content.ContentType.Alias].Invoke(CreatePageCommandBase)
                : PageMapper.PageMap[Constants.Constants.Factories.DefaultKey].Invoke(CreatePageCommandBase);
        }
    }
}
