using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Queries;

/// <summary>
/// Implements the <see cref="MemberByEmail"/> query
/// </summary>
/// <typeparam name="TMember"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class MemberByEmailQuery<TMember, TProperty>
    where TMember : IMember<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets a member by email
    /// </summary>
    /// <param name="memberRepository"></param>
    /// <param name="email"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets a member by email.")]
    [UseFiltering]
    [UseSorting]
    public virtual TMember? MemberByEmail([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                            [GraphQLDescription("The email to fetch.")] string email)
    {
        return memberRepository.GetMember(x => x.GetByEmail(email));
    }
}