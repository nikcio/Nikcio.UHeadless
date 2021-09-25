using Newtonsoft.Json;
using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Factories.Sites;
using Nikcio.Umbraco.Headless.Core.Json;
using Nikcio.Umbraco.Headless.Core.Repositories;

namespace Nikcio.Umbraco.Headless.Core.Services
{
    public class HeadlessService : IHeadlessService
    {
        private readonly ISiteFactory siteFactory;

        public HeadlessService(IUmbracoContentRepository headlessRepository, ISiteFactory siteFactory)
        {
            HeadlessRepository = headlessRepository;
            this.siteFactory = siteFactory;
        }

        public IUmbracoContentRepository HeadlessRepository { get; }

        public object GetData(string route, string culture = null)
        {
            var content = HeadlessRepository.GetContentAtRoute(route);
            siteFactory.SetCreateSiteCommandBase(content, culture);
            return JsonConvert.SerializeObject(siteFactory.GetSiteData(), new JsonSerializerSettings() { ContractResolver = new DefaultHeadlessResolver() });
        }
    }

}
