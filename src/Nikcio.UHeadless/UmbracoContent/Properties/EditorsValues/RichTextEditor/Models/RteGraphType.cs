using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Umbraco.Cms.Core.Strings;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.RichTextEditor.Models
{
    public class RteGraphType : PropertyValueBaseGraphType
    {
        public string Value { get; set; }

        public RteGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            Value = ((IHtmlEncodedString)createPropertyValue.Property.GetValue(createPropertyValue.Culture)).ToHtmlString();
        }
    }
}
