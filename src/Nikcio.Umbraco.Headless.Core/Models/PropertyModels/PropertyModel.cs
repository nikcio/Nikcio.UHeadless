using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements
{
    public class PropertyModel : PropertyModelBase, IPropertyModel
    {
        public virtual string Alias { get; set; }
        public virtual string DataType { get; set; }
        public virtual object Value { get; set; }

        public PropertyModel(IPublishedProperty property)
        {
            Alias = property.Alias;
            DataType = property.PropertyType.DataType.EditorAlias;
            Value = property.GetValue();
        }
    }
}
