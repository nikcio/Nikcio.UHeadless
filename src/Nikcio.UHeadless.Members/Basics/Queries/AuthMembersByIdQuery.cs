using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the MembersById query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMembersByIdQuery : MembersByIdQuery<BasicMember>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicMember?> MembersById([Service] IMemberRepository<BasicMember> memberRepository, [GraphQLDescription("The ids to fetch.")] int[] ids)
    {
        return base.MembersById(memberRepository, ids);
    }
}
