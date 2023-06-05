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
/// The default query implementation of the MemberByKey query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMemberByKeyQuery : MemberByKeyQuery<BasicMember, BasicProperty>
{
    /// <inheritdoc/>
    [Authorize]
    public override BasicMember? MemberByKey([Service] IMemberRepository<BasicMember, BasicProperty> memberRepository, [GraphQLDescription("The key to fetch.")] Guid key)
    {
        return base.MemberByKey(memberRepository, key);
    }
}
