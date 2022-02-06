using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Models
{
    [GraphQLDescription("Represents a property.")]
    public interface IPropertyGraphType
    {
        [GraphQLDescription("Gets the alias of a property.")]
        string Alias { get; }

        [GraphQLDescription("Gets the value of a property.")]
        object Value { get; }

        [GraphQLDescription("Gets the editor alias of a property.")]
        string EditorAlias { get; set; }
    }

}
