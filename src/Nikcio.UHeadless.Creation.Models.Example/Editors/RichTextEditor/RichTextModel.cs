using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.DeliveryApi;
using Umbraco.Cms.Core.Models.DeliveryApi;
using Umbraco.Cms.Core.Strings;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.RichTextEditor;

/// <summary>
/// Represents a rich text editor
/// </summary>
public class RichTextModel : PropertyValue
{
    /// <summary>
    /// Gets the HTML value of the rich text editor or markdown editor
    /// </summary>
    public virtual IRichTextElement? Value { get; set; }

    /// <summary>
    /// Gets the original value of the rich text editor or markdown editor
    /// </summary>
    public virtual string? SourceValue { get; set; }

    /// <inheritdoc/>
    public RichTextModel(CreatePropertyValue createPropertyValue, IApiRichTextElementParser apiRichTextElementParser) : base(createPropertyValue)
    {
        var propertyValue = createPropertyValue.Property.Value<IHtmlEncodedString?>(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (propertyValue == null)
        {
            return;
        }

        var html = propertyValue.ToHtmlString();
        if (string.IsNullOrWhiteSpace(html))
        {
            return;
        }

        Value = apiRichTextElementParser.Parse(html);
        SourceValue = createPropertyValue.Property.GetSourceValue(createPropertyValue.Culture)?.ToString();
    }
}
