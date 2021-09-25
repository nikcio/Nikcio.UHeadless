using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Repositories
{
    public interface IUmbracoContentRepository
    {
        IPublishedContent GetContentAtRoute(string route, bool preview = false, string culture = null);
    }
}