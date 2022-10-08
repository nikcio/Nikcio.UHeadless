using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.ContentTypes.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Queries;

namespace Nikcio.UHeadless.Media.Basics.Queries;

/// <summary>
/// The default implementation of the Media queries
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicMediaQuery : MediaQuery<BasicMedia<BasicProperty, BasicContentType>, BasicProperty>
{
}
