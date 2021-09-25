using Newtonsoft.Json;
using Nikcio.Umbraco.Headless.Core.Factories.Sites;
using Nikcio.Umbraco.Headless.Core.Json.Resolvers;
using Nikcio.Umbraco.Headless.Core.Repositories.Umbraco.Content;

namespace Nikcio.Umbraco.Headless.Core.Services.Headless
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
            return JsonConvert.SerializeObject(siteFactory.GetSiteData(content, culture), new JsonSerializerSettings() { ContractResolver = new DefaultHeadlessResolver() });
        }
    }

}
