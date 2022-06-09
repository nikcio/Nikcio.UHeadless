using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Properties.Models;

namespace Nikcio.UHeadless.Properties.Queries {
    /// <summary>
    /// The default implementation for the property queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicPropertyQuery : PropertyQuery<BasicProperty> {
    }
}
