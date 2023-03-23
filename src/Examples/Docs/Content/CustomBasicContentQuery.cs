using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Examples.Docs.Content;

[ExtendObjectType(typeof(Query))]
public class CustomBasicContentQuery : ContentQuery<CustomBasicContent, BasicProperty, BasicContentRedirect>
{
}
