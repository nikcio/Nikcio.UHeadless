using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Repositories
{
    public interface IHeadlessRepository
    {
        IPublishedContent GetContentAtRoute(string route, bool preview = false, string culture = null);
    }
}