using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;
using Umbraco.Cms.Core.Persistence.Querying;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the FindMembersByUsername query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthFindMembersByUsernameQuery : FindMembersByUsernameQuery<BasicMember>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicMember?> FindMembersByUsername([Service] IMemberRepository<BasicMember> memberRepository, [GraphQLDescription("The username (may be partial).")] string username, [GraphQLDescription("The page index.")] long pageIndex, [GraphQLDescription("The page size.")] int pageSize, [GraphQLDescription("Determines how to match a string property value.")] StringPropertyMatchType matchType)
    {
        return base.FindMembersByUsername(memberRepository, username, pageIndex, pageSize, matchType);
    }
}
