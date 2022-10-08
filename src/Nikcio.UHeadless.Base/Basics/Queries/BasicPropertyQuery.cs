using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Queries;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Basics.Properties.Queries;

/// <summary>
/// The default implementation for the property queries
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicPropertyQuery : PropertyQuery<BasicProperty>
{
}
