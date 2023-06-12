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
/// The default query implementation of the FindMembersByDisplayName query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthFindMembersByDisplayNameQuery : FindMembersByDisplayNameQuery<BasicMember>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicMember?> FindMembersByDisplayName([Service] IMemberRepository<BasicMember> memberRepository, [GraphQLDescription("The display name (may be partial).")] string displayName, [GraphQLDescription("The page index.")] long pageIndex, [GraphQLDescription("The page size.")] int pageSize, [GraphQLDescription("Determines how to match a string property value.")] StringPropertyMatchType matchType)
    {
        return base.FindMembersByDisplayName(memberRepository, displayName, pageIndex, pageSize, matchType);
    }
}
