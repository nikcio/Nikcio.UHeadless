using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the AllMembers query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthAllMembersQuery : AllMembersQuery<BasicMember, BasicProperty>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicMember?> AllMembers([Service] IMemberRepository<BasicMember, BasicProperty> memberRepository, [GraphQLDescription("The current page index.")] long pageIndex, [GraphQLDescription("The page size.")] int pageSize, [GraphQLDescription("The field to order by.")] string orderBy, [GraphQLDescription("The direction to order by.")] Direction orderDirection, [GraphQLDescription("The member type alias to search for.")] string? memberTypeAlias = null, [GraphQLDescription("The search text filter.")] string? filter = null)
    {
        return base.AllMembers(memberRepository, pageIndex, pageSize, orderBy, orderDirection, memberTypeAlias, filter);
    }
}
