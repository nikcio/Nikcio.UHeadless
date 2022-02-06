using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Models
{
    public class PublishedPropertyGraphType : IPublishedPropertyGraphType
    {
        public string Alias { get; set; }

        [GraphQLType(typeof(AnyType))]
        public object Value { get; set; }

        public string EditorAlias { get; set; }
    }
}
