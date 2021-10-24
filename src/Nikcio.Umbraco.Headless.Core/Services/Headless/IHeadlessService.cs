using Nikcio.Umbraco.Headless.Core.Repositories.Umbraco.Content;

namespace Nikcio.Umbraco.Headless.Core.Services.Headless
{
    public interface IHeadlessService
    {
        IUmbracoContentRepository HeadlessRepository { get; }
        object GetData(string route);
        object GetData(string route, string culture);
    }
}
