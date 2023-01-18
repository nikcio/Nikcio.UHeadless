using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Strings;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.RichTextEditor.Models;

/// <summary>
/// Represents a rich text editor
/// </summary>
[GraphQLDescription("Represents a rich text editor.")]
public class BasicRichText : PropertyValue
{
    /// <summary>
    /// Gets the HTML value of the rich text editor or markdown editor
    /// </summary>
    [GraphQLDescription("Gets the HTML value of the rich text editor or markdown editor.")]
    public virtual string? Value { get; set; }

    /// <summary>
    /// Gets the original value of the rich text editor or markdown editor
    /// </summary>
    [GraphQLDescription("Gets the original value of the rich text editor or markdown editor.")]
    public virtual string? SourceValue { get; set; }

    /// <inheritdoc/>
    public BasicRichText(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        var propertyValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        if (propertyValue == null)
        {
            return;
        }
        Value = ((IHtmlEncodedString) propertyValue)?.ToHtmlString();
        SourceValue = createPropertyValue.Property.GetSourceValue(createPropertyValue.Culture)?.ToString();
    }
}
