using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Models {
    /// <summary>
    /// A base for property values
    /// </summary>
    [InterfaceType]
    public abstract class PropertyValue : IDiscoverable {
        /// <inheritdoc/>
        protected PropertyValue(CreatePropertyValue createPropertyValue) {
            Alias = createPropertyValue.GetAlias() ?? "Unknown";
        }

        /// <summary>
        /// The property alias
        /// </summary>
        public string Alias { get; }
    }
}
