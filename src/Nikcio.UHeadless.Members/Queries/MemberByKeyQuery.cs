using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Queries;

/// <summary>
/// Implements the <see cref="MemberByKey"/> query
/// </summary>
/// <typeparam name="TMember"></typeparam>
/// <typeparam name="TProperty"></typeparam>
public class MemberByKeyQuery<TMember, TProperty>
    where TMember : IMember<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets a member by key
    /// </summary>
    /// <param name="memberRepository"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    [GraphQLDescription("Gets a member by key.")]
    [UseFiltering]
    [UseSorting]
    public virtual TMember? MemberByKey([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                            [GraphQLDescription("The key to fetch.")] Guid key)
    {
        return memberRepository.GetMember(x => x.GetByKey(key));
    }
}