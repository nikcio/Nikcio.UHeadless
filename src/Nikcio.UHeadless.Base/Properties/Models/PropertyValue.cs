using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Commands;
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
            publishedProperty = createPropertyValue.Property;
        }

        protected readonly IPublishedProperty publishedProperty;

        public string Alias => publishedProperty.Alias;
    }
}
