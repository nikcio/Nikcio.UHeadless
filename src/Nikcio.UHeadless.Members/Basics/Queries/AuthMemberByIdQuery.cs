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
/// The default query implementation of the MemberById query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMemberByIdQuery : MemberByIdQuery<BasicMember, BasicProperty>
{
    /// <inheritdoc/>
    [Authorize]
    public override BasicMember? MemberById([Service] IMemberRepository<BasicMember, BasicProperty> memberRepository, [GraphQLDescription("The id to fetch.")] int id)
    {
        return base.MemberById(memberRepository, id);
    }
}
