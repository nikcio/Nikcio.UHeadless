using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Content.Models;
using Nikcio.UHeadless.Basics.ContentTypes.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Basics.Content.Queries {
    /// <summary>
    /// The default implementation of the content queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty, BasicContentRedirect> {
    }
}
