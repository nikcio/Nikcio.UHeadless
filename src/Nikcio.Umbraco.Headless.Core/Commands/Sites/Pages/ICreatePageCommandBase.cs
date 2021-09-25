using Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers;
using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages
{
    public interface ICreatePageCommandBase
    {
        IPublishedContent Content { get; set; }
        IPublishedValueFallback PublishedValueFallback { get; set; }
        string Culture { get; set; }
        IPageDataFactory PageDataFactory { get; set; }

        void SetCreatePageCommandBase(ICreateSiteCommandBase createSiteCommandBase);
    }
}