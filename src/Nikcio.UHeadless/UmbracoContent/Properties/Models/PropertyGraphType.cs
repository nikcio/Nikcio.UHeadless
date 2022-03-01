using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Models
{
    [GraphQLDescription("Represents a property.")]
    public class PropertyGraphType : IPropertyGraphTypeBase
    {
        [GraphQLDescription("Gets the alias of a property.")]
        public virtual string Alias { get; set; }

        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of a property.")]
        public virtual object Value { get; set; }

        [GraphQLDescription("Gets the editor alias of a property.")]
        public virtual string EditorAlias { get; set; }
    }
}
