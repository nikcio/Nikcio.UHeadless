using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.Blocks;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels
{
    public class BlockPropertyModel<TBlockItemModel> : PropertyModel where TBlockItemModel : class, IBlockItemModel
    {
        public new List<TBlockItemModel> Value { get; set; }

        public BlockPropertyModel(ICreatePropertyCommandBase createPropertyCommandBase) : base(createPropertyCommandBase)
        {
            var blockListModel = (BlockListModel)createPropertyCommandBase.Property.GetValue(createPropertyCommandBase.Culture);

            var blockItems = new List<TBlockItemModel>();
            foreach (var blockItem in blockListModel)
            {
                var propertyList = Activator.CreateInstance(typeof(TBlockItemModel)) as TBlockItemModel;
                foreach (var propertyItem in blockItem.Content.Properties)
                {
                    createPropertyCommandBase.Property = propertyItem;
                    propertyList.PropertyList.Add(createPropertyCommandBase.PageDataFactory.GetPropertyData());
                }
                blockItems.Add(propertyList);
            }

            Value = blockItems;
        }
    }
}
