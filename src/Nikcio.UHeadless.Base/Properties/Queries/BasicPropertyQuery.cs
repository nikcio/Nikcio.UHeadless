using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Base.Properties.Queries {
    /// <summary>
    /// The default implementation for the property queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicPropertyQuery : PropertyQuery<BasicProperty> {
    }
}
