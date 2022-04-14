using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public abstract class Property : IProperty {
        /// <inheritdoc/>
        protected Property(CreateProperty _) {
        }
    }
}
