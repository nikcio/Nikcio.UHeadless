using Nikcio.Umbraco.Headless.Core.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements
{
    public class BlockPropertyModel : PropertyModel
    {
        public new object Value { get; set; }

        public BlockPropertyModel(IPublishedProperty property, IPublishedContent content, IPageDataFactory pageDataFactory) : base(property)
        {
            var blockListModel = ((BlockListModel)property.GetValue());

            var propertyList = new List<IPropertyModelBase>();
            foreach (var blockItem in blockListModel)
            {
                foreach (var propertyItem in blockItem.Content.Properties)
                {
                    propertyList.Add(pageDataFactory.GetPropertyData(propertyItem, content));
                }
            }

            Value = propertyList;
        }
    }
}
