using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using Umbraco.Cms.Core.Strings;

namespace Nikcio.UHeadless.Models.Properties.RichTextEditor
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
