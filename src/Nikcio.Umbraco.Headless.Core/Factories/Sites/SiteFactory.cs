using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.SiteData;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites
{
    public class SiteFactory : ISiteFactory
    {
        public ICreateSiteCommandBase CreateSiteCommandBase { get; protected set; }

        public SiteFactory(ICreateSiteCommandBase createSiteCommandBase)
        {
            AddSiteMapDefaults();
            CreateSiteCommandBase = createSiteCommandBase;
        }

        private static void AddSiteMapDefaults()
        {
            if (!SiteMapper.SiteMap.ContainsKey(Constants.Constants.Factories.DefaultKey))
            {
                SiteMapper.AddMapping(Constants.Constants.Factories.DefaultKey, (x) => new BaseSiteModel(x));
            }
        }

        public void SetCreateSiteCommandBase(IPublishedContent publishedContent, string culture)
        {
            CreateSiteCommandBase.SetCreateSiteCommandBase(publishedContent, culture);
        }

        public ISiteModelBase GetSiteData(IPublishedContent publishedContent, string culture)
        {
            SetCreateSiteCommandBase(publishedContent, culture);
            return SiteMapper.SiteMap.ContainsKey(CreateSiteCommandBase.Content.ContentType.Alias)
                ? SiteMapper.SiteMap[CreateSiteCommandBase.Content.ContentType.Alias].Invoke(CreateSiteCommandBase)
                : SiteMapper.SiteMap[Constants.Constants.Factories.DefaultKey].Invoke(CreateSiteCommandBase);
        }
    }
}
