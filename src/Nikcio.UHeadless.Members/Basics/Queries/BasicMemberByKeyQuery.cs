using HotChocolate.Types;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the MemberByKey query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class BasicMemberByKeyQuery : MemberByKeyQuery<BasicMember, BasicProperty>
{
}
