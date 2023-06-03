using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Nikcio.UHeadless.Members.Repositories;
using Umbraco.Cms.Core.Persistence.Querying;

namespace Nikcio.UHeadless.Members.Queries;

/// <summary>
/// Implements the <see cref="FindMembersByRole"/> query
/// </summary>
/// <typeparam name="TMember"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class FindMembersByRoleQuery<TMember, TProperty>
    where TMember : IMember<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Finds members by role
    /// </summary>
    /// <param name="memberRepository"></param>
    /// <param name="roleName"></param>
    /// <param name="usernameToMatch"></param>
    /// <param name="matchType"></param>
    /// <returns></returns>
    [GraphQLDescription("Finds members by role.")]
    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public virtual IEnumerable<TMember?> FindMembersByRole([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                            [GraphQLDescription("The role name.")] string roleName,
                                            [GraphQLDescription("The username to match.")] string usernameToMatch,
                                            [GraphQLDescription("Determines how to match a string property value.")] StringPropertyMatchType matchType)
    {
        return memberRepository.GetMemberList(x => x.FindMembersInRole(roleName, usernameToMatch, matchType));
    }
}