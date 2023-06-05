using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Members.Basics.Models;
using Nikcio.UHeadless.Members.Queries;
using Nikcio.UHeadless.Members.Repositories;
using Umbraco.Cms.Core.Persistence.Querying;

namespace Nikcio.UHeadless.Members.Basics.Queries;

/// <summary>
/// The default query implementation of the FindMembersByRole query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthFindMembersByRoleQuery : FindMembersByRoleQuery<BasicMember, BasicProperty>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicMember?> FindMembersByRole([Service] IMemberRepository<BasicMember, BasicProperty> memberRepository, [GraphQLDescription("The role name.")] string roleName, [GraphQLDescription("The username to match.")] string usernameToMatch, [GraphQLDescription("Determines how to match a string property value.")] StringPropertyMatchType matchType)
    {
        return base.FindMembersByRole(memberRepository, roleName, usernameToMatch, matchType);
    }
}
