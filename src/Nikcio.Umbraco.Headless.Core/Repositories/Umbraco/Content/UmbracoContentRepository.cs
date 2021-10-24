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

        public virtual IPublishedContent GetContentAtRoute(string route)
        {
            return GetContentAtRoute(route, false, null);
        }

        public virtual IPublishedContent GetContentAtRoute(string route, bool preview)
        {
            return GetContentAtRoute(route, preview, null);
        }

        public virtual IPublishedContent GetContentAtRoute(string route, bool preview, string culture)
        {
            return _umbracoContext.Content.GetByRoute(preview, route, culture: culture);
        }
    }
}
