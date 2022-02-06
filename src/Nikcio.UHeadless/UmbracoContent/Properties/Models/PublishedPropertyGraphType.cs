using HotChocolate;
using HotChocolate.Types;

namespace Nikcio.UHeadless.Models.Dtos.Propreties
{
    public class PublishedPropertyGraphType : IPublishedPropertyGraphType
    {
        public string Alias { get; set; }

        [GraphQLType(typeof(AnyType))]
        public object Value { get; set; }

        public string EditorAlias { get; set; }
    }
}
