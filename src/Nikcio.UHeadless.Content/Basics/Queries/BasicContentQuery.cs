using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default implementation of the content queries
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType, BasicContentRedirect>, BasicProperty, BasicContentRedirect>
{
}
