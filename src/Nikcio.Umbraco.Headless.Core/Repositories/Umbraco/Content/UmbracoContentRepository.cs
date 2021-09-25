using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace Nikcio.Umbraco.Headless.Core.Repositories.Umbraco.Content
{
    public class UmbracoContentRepository : IUmbracoContentRepository
    {
        private readonly IUmbracoContext _umbracoContext;

        public UmbracoContentRepository(IUmbracoContextAccessor umbracoContext)
        {
            umbracoContext.TryGetUmbracoContext(out _umbracoContext);
        }

        public virtual IPublishedContent GetContentAtRoute(string route, bool preview = false, string culture = null)
        {
            return _umbracoContext.Content.GetByRoute(preview, route, culture: culture);
        }
    }
}
