using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the MemberByEmail query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMemberByEmailQuery : MemberByEmailQuery<BasicMember, BasicProperty>
{
    /// <inheritdoc/>
    [Authorize]
    public override BasicMember? MemberByEmail([Service] IMemberRepository<BasicMember, BasicProperty> memberRepository, [GraphQLDescription("The email to fetch.")] string email)
    {
        return base.MemberByEmail(memberRepository, email);
    }
}
