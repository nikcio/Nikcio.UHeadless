using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels
{
    public interface IBlockItemModel
    {
        List<IPropertyModelBase> PropertyList { get; set; }
    }
}
