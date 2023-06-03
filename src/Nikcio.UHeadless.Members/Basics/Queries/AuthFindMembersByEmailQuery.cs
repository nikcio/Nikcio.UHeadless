using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;
using Umbraco.Cms.Core.Persistence.Querying;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the FindMembersByEmail query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthFindMembersByEmailQuery : FindMembersByEmailQuery<BasicMember, BasicProperty>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicMember?> FindMembersByEmail([Service] IMemberRepository<BasicMember, BasicProperty> memberRepository, [GraphQLDescription("The email (may be partial).")] string email, [GraphQLDescription("The page index.")] long pageIndex, [GraphQLDescription("The page size.")] int pageSize, [GraphQLDescription("Determines how to match a string property value.")] StringPropertyMatchType matchType)
    {
        return base.FindMembersByEmail(memberRepository, email, pageIndex, pageSize, matchType);
    }
}
