using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.SiteData;
using System;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Factories.Sites
{
    public class SiteFactory : ISiteFactory
    {
        private readonly ISiteMapper siteMapper;

        public ICreateSiteCommandBase CreateSiteCommandBase { get; protected set; }

        public SiteFactory(ICreateSiteCommandBase createSiteCommandBase, ISiteMapper siteMapper)
        {
            AddSiteMapDefaults();
            CreateSiteCommandBase = createSiteCommandBase;
            this.siteMapper = siteMapper;
        }

        private void AddSiteMapDefaults()
        {
            if (!siteMapper.ContainsKey(Constants.Constants.Factories.DefaultKey))
            {
                siteMapper.AddMapping(Constants.Constants.Factories.DefaultKey, typeof(BaseSiteModel));
            }
        }

        public void SetCreateSiteCommandBase(IPublishedContent publishedContent, string culture)
        {
            CreateSiteCommandBase.SetCreateSiteCommandBase(publishedContent, culture);
        }

        public ISiteModelBase GetSiteData(IPublishedContent publishedContent, string culture)
        {
            SetCreateSiteCommandBase(publishedContent, culture);
            return (ISiteModelBase)(siteMapper.ContainsKey(CreateSiteCommandBase.Content.ContentType.Alias)
                ? Activator.CreateInstance(siteMapper.GetValue(CreateSiteCommandBase.Content.ContentType.Alias))
                : Activator.CreateInstance(siteMapper.GetValue(Constants.Constants.Factories.DefaultKey)));
        }
    }
}
