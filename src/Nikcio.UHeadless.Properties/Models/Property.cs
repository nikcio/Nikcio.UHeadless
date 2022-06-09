using HotChocolate;
using Nikcio.UHeadless.Properties.Commands;

namespace Nikcio.UHeadless.Properties.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public abstract class Property : IProperty {
        /// <inheritdoc/>
        protected Property(CreateProperty _) {
        }
    }
}
