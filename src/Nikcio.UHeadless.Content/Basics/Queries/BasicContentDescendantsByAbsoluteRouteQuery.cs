using HotChocolate.Types;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default query implementation of the ContentDescendantsByAbsoluteRoute query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicContentDescendantsByAbsoluteRouteQuery : ContentDescendantsByAbsoluteRouteQuery<BasicContent, BasicContentRedirect>
{
}
