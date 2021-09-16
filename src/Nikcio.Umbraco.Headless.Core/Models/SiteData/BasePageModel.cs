using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models
{
    public class BasePageModel : PublishedContentModel
    {
        public List<IPropertyModel> PageProperties { get; set; }

        public BasePageModel(IPublishedContent content, IPublishedValueFallback publishedValueFallback) : base(content, publishedValueFallback)
        {
            PageProperties = Properties.Select(p => PropertyModel.Create(p)).ToList();
        }
    }
}
