using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the MemberByEmail query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMemberByEmailQuery : MemberByEmailQuery<BasicMember>
{
    /// <inheritdoc/>
    [Authorize]
    public override BasicMember? MemberByEmail([Service] IMemberRepository<BasicMember> memberRepository, [GraphQLDescription("The email to fetch.")] string email)
    {
        return base.MemberByEmail(memberRepository, email);
    }
}
