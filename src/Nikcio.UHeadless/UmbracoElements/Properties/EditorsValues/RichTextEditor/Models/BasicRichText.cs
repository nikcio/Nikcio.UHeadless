using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Umbraco.Cms.Core.Strings;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.RichTextEditor.Models {
    /// <summary>
    /// Represents a rich text editor
    /// </summary>
    [GraphQLDescription("Represents a rich text editor.")]
    public class BasicRichText : PropertyValue {
        /// <summary>
        /// Gets the value of the rich text editor
        /// </summary>
        [GraphQLDescription("Gets the value of the rich text editor.")]
        public virtual string Value { get; set; }

        /// <inheritdoc/>
        public BasicRichText(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            Value = ((IHtmlEncodedString) createPropertyValue.Property.GetValue(createPropertyValue.Culture)).ToHtmlString();
        }
    }
}
