using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Fallback.Commands;
using Umbraco.Cms.Core.Strings;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.RichTextEditor.Models
{
    /// <summary>
    /// Represents a rich text editor
    /// </summary>
    [GraphQLDescription("Represents a rich text editor.")]
    public class BasicRichText : PropertyValue
    {
        /// <summary>
        /// Gets the value of the rich text editor
        /// </summary>
        [GraphQLDescription("Gets the value of the rich text editor.")]
        public virtual string Value { get; set; }

        /// <inheritdoc/>
        public BasicRichText(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            Value = ((IHtmlEncodedString)createPropertyValue.Property.GetValue(createPropertyValue.Culture)).ToHtmlString();
        }
    }
}
