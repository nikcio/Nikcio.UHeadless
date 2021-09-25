using Nikcio.Umbraco.Headless.Core.Factories.Sites.Pages.PageData;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData
{
    public interface ICreatePropertyCommandBase
    {
        public IPublishedContent Content { get; set; }
        public IPublishedProperty Property { get; set; }
        public string Culture { get; set; }
        public IPageDataFactory PageDataFactory { get; set; }

        void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase);
    }
}