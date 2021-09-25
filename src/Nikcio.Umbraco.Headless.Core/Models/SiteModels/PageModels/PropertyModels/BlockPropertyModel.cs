using Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements
{
    public class BlockPropertyModel : PropertyModel
    {
        public new List<IPropertyModelBase> Value { get; set; }

        public BlockPropertyModel(ICreatePropertyCommandBase createPropertyCommandBase) : base(createPropertyCommandBase)
        {
            var blockListModel = (BlockListModel)createPropertyCommandBase.Property.GetValue(createPropertyCommandBase.Culture);

            var propertyList = new List<IPropertyModelBase>();
            foreach (var blockItem in blockListModel)
            {
                foreach (var propertyItem in blockItem.Content.Properties)
                {
                    createPropertyCommandBase.Property = propertyItem;
                    propertyList.Add(createPropertyCommandBase.PageDataFactory.GetPropertyData());
                }
            }

            Value = propertyList;
        }
    }
}
