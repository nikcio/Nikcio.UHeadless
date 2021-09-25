using Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers
{
    public class CreatePropertyCommandBase : ICreatePropertyCommandBase
    {
        public IPublishedContent Content { get; set; }
        public IPublishedProperty Property { get; set; }
        public string Culture { get; set; }
        public IPageDataFactory PageDataFactory { get; set; }

        public void SetCreatePropertyCommandBase(ICreatePageCommandBase createPageCommandBase)
        {
            Content = createPageCommandBase.Content;
            Culture = createPageCommandBase.Culture;
            PageDataFactory = createPageCommandBase.PageDataFactory;
        }
    }
}
