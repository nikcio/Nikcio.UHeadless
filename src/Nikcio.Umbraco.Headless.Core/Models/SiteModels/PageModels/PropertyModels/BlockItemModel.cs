using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels
{
    public class BlockItemModel : IBlockItemModel
    {
        private List<IPropertyModelBase> propertyList = new();

        public virtual List<IPropertyModelBase> PropertyList { get => propertyList; set => propertyList = value; }
    }
}
