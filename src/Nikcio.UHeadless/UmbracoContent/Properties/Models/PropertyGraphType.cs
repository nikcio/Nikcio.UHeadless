using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a property.")]
    public class PropertyGraphType : IPropertyGraphTypeBase
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
