using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Queries {
    /// <summary>
    /// The default implementation of the content queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType>, BasicProperty> {
    }
}
