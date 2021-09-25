using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Web.Common.UmbracoContext;

namespace Nikcio.Umbraco.Headless.Core.Repositories
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
