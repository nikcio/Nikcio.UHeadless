using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the FindMembersByDisplayName query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicFindMembersByDisplayNameQuery : FindMembersByDisplayNameQuery<BasicMember>
{
}
