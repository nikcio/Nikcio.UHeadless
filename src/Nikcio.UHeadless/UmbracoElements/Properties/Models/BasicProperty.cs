using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public class BasicProperty : IProperty
    {
        /// <inheritdoc/>
        [GraphQLDescription("Gets the alias of a property.")]
        public virtual string? Alias { get; set; }

        /// <inheritdoc/>
        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of a property.")]
        public virtual object? Value { get; set; }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the editor alias of a property.")]
        public virtual string? EditorAlias { get; set; }
    }
}
