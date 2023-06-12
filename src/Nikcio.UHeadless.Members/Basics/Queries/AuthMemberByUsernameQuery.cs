using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the MemberByUsername query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMemberByUsernameQuery : MemberByUsernameQuery<BasicMember>
{
    /// <inheritdoc/>
    [Authorize]
    public override BasicMember? MemberByUsername([Service] IMemberRepository<BasicMember> memberRepository, [GraphQLDescription("The username to fetch.")] string username)
    {
        return base.MemberByUsername(memberRepository, username);
    }
}
