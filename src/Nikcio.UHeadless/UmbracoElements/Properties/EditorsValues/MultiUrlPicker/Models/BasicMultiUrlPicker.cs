using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MultiUrlPicker.Models {
    /// <summary>
    /// Represents a multi url picker
    /// </summary>
    [GraphQLDescription("Represents a multi url picker.")]
    public class BasicMultiUrlPicker : PropertyValue {
        /// <summary>
        /// Gets the links
        /// </summary>
        [GraphQLDescription("Gets the links.")]
        public virtual List<BasicLink> Links { get; set; } = new();

        /// <inheritdoc/>
        public BasicMultiUrlPicker(CreatePropertyValue createPropertyValue) : base(createPropertyValue) {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value is IEnumerable<Link> links) {
                foreach (var link in links) {
                    Links.Add(new BasicLink(link));
                }
            }
        }
    }
}
