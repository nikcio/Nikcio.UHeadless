using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Nikcio.UHeadless.Members.Repositories;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Members.Queries {
    /// <summary>
    /// The base implementation of the Member queries
    /// </summary>
    /// <typeparam name="TMember"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    public class MemberQuery<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {

        /// <summary>
        /// Gets a member by id
        /// </summary>
        /// <param name="memberRepository"></param>
        /// <param name="id"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a member by id.")]
        [UseFiltering]
        [UseSorting]
        public virtual TMember? GetMemberById([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                                [GraphQLDescription("The id to fetch.")] int id,
                                                [GraphQLDescription("The culture.")] string? culture = null) {
            return memberRepository.GetMember(x => x.GetById(id), culture);
        }

        /// <summary>
        /// Gets all members by filter
        /// </summary>
        /// <param name="memberRepository"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="orderDirection"></param>
        /// <param name="orderBy"></param>
        /// <param name="memberTypeAlias"></param>
        /// <param name="filter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets all members by filter and/or pageindex.")]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TMember?> GetAllMembers([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                                [GraphQLDescription("The current page index.")] int pageIndex,
                                                [GraphQLDescription("The page size.")] int pageSize,
                                                [GraphQLDescription("The field to order by.")] string orderBy,
                                                [GraphQLDescription("The direction to order by.")] Direction orderDirection,
                                                [GraphQLDescription("The member type alias to search for.")] string? memberTypeAlias = null,
                                                [GraphQLDescription("The search text filter.")] string filter = "",
                                                [GraphQLDescription("The culture.")] string? culture = null) {
            return memberRepository.GetMemberList(x => x.GetAll(pageIndex, pageSize, out _, orderBy, orderDirection, memberTypeAlias, filter), culture);
        }

        /// <summary>
        /// Gets a members by id
        /// </summary>
        /// <param name="memberRepository"></param>
        /// <param name="ids"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets members by id.")]
        [UseFiltering]
        [UseSorting]
        public virtual IEnumerable<TMember?> GetMembersById([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                                [GraphQLDescription("The ids to fetch.")] int[] ids,
                                                [GraphQLDescription("The culture.")] string? culture = null) {
            return memberRepository.GetMemberList(x => x.GetAllMembers(ids), culture);
        }

        /// <summary>
        /// Gets a member by email
        /// </summary>
        /// <param name="memberRepository"></param>
        /// <param name="email"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a member by email.")]
        [UseFiltering]
        [UseSorting]
        public virtual TMember? GetMemberByEmail([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                                [GraphQLDescription("The email to fetch.")] string email,
                                                [GraphQLDescription("The culture.")] string? culture = null) {
            return memberRepository.GetMember(x => x.GetByEmail(email), culture);
        }

        /// <summary>
        /// Gets a member by key
        /// </summary>
        /// <param name="memberRepository"></param>
        /// <param name="key"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a member by key.")]
        [UseFiltering]
        [UseSorting]
        public virtual TMember? GetMemberByKey([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                                [GraphQLDescription("The key to fetch.")] Guid key,
                                                [GraphQLDescription("The culture.")] string? culture = null) {
            return memberRepository.GetMember(x => x.GetByKey(key), culture);
        }

        /// <summary>
        /// Gets a member by username
        /// </summary>
        /// <param name="memberRepository"></param>
        /// <param name="username"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        [GraphQLDescription("Gets a member by username.")]
        [UseFiltering]
        [UseSorting]
        public virtual TMember? GetMemberByUsername([Service] IMemberRepository<TMember, TProperty> memberRepository,
                                                [GraphQLDescription("The username to fetch.")] string username,
                                                [GraphQLDescription("The culture.")] string? culture = null) {
            return memberRepository.GetMember(x => x.GetByUsername(username), culture);
        }
    }
}