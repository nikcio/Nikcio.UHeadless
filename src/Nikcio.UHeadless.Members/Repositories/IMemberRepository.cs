using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;

namespace Nikcio.UHeadless.Members.Repositories {
    /// <summary>
    /// A repository to get Member from Umbraco
    /// </summary>
    public interface IMemberRepository<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {
        /// <summary>
        /// Gets the Member based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        TMember? GetMember(Func<IPublishedMemberCache?, IPublishedContent?> fetch, string? culture);

        /// <summary>
        /// Gets a Member lsit based on a fetch method
        /// </summary>
        /// <param name="fetch">The fetch method</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        IEnumerable<TMember?> GetMemberList(Func<IPublishedMemberCache?, IEnumerable<IPublishedContent>?> fetch, string? culture);

        /// <summary>
        /// Gets a <see cref="IPublishedContent"/> converted to T
        /// </summary>
        /// <param name="Member">The published Member</param>
        /// <param name="culture">The culture</param>
        /// <returns></returns>
        TMember? GetConvertedMember(IPublishedContent Member, string culture);
    }
}