using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.Umbraco.Headless.Core.Models
{
    public class BaseDataModel
    {
        public BaseSiteInformationModel Site { get; set; }
        public BaseNavigationModel Navigation { get; set; }
        public BasePageModel Content { get; set; }
        public BaseFooterModel Footer { get; set; }
    }
}
