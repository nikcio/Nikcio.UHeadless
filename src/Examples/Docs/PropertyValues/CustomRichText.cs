using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.RichTextEditor.Models;

namespace Examples.Docs.PropertyValues;

public class CustomRichText : BasicRichText
{

    public string MyCustomProperty { get; set; }

    public CustomRichText(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        MyCustomProperty = "Hello here is a property";
    }
}
