using Nikcio.Umbraco.Headless.Core.Factories;
using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models
{
    public class BasePageModel : PublishedContentModel
    {
        /// <summary>
        /// THIS IS NOT FOR USE
        /// </summary>
        public BasePageModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
        }

        public new List<IPropertyModelBase> Properties { get; set; }

        public BasePageModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback, IPageDataFactory pageDataFactory) : base(content, publishedValueFallback)
        {
            Properties = base.Properties.Select(p => pageDataFactory.GetPropertyData(p, content)).ToList();
        }
    }
}
