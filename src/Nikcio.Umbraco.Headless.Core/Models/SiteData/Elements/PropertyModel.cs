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

        public static IPropertyModel Create(IPublishedProperty publishedProperty)
        {
            return new PropertyModel(publishedProperty);
        }
    }

    public static class ObjectExtentions
    {
        public static object FormatValue(this object value, string editorAlias)
        {
            var stringValue = value.ToString();

            if(editorAlias == UmbracoConstants.PropertyEditors.Aliases.BlockList)
            {
                return stringValue.FormatBlockValue();
            }

            return stringValue;
        }

        private static object FormatBlockValue(this string blockValue)
        {
            return JsonConvert.DeserializeObject(Regex.Replace(blockValue, @"((\\r\\n)|(\\\\r\\\\n)|(?<=[}\]])""|""(?=[{\[])|[\\])", string.Empty, RegexOptions.IgnoreCase));
        }
    }
}
