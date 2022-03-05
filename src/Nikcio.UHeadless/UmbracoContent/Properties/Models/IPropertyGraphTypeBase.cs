using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Models
{
    /// <summary>
    /// Represents a property
    /// </summary>
    [GraphQLDescription("Represents a property.")]
    public interface IPropertyGraphTypeBase
    {
        /// <summary>
        /// Gets the alias of a property
        /// </summary>
        [GraphQLDescription("Gets the alias of a property.")]
        string? Alias { get; set; }

        /// <summary>
        /// Gets the value of a property
        /// </summary>
        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of a property.")]
        object? Value { get; set; }

        /// <summary>
        /// Gets the editor alias of a property
        /// </summary>
        [GraphQLDescription("Gets the editor alias of a property.")]
        string? EditorAlias { get; set; }
    }

}
