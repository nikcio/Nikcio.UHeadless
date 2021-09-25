using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels
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
