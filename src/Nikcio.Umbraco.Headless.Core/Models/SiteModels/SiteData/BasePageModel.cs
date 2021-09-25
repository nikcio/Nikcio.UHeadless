using Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers;
using Nikcio.Umbraco.Headless.Core.Models.PageModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models
{
    public class BasePageModel : PublishedContentModel, IPageModelBase
    {
        /// <summary>
        /// THIS IS NOT FOR USE
        /// </summary>
        public BasePageModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public new List<IPropertyModelBase> Properties { get; set; }

        public BasePageModel(ICreatePageCommandBase createPageCommandBase) : base(createPageCommandBase.Content, createPageCommandBase.PublishedValueFallback)
        {
            Properties = base.Properties.Select(p =>
            {
                createPageCommandBase.PageDataFactory.CreatePropertyCommandBase.Property = p;
                return createPageCommandBase.PageDataFactory.GetPropertyData(createPageCommandBase);
            }).ToList();
        }
    }
}
