using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Elements.Repositories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Factories;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Members.Repositories {
    /// <inheritdoc/>
    public class MemberRepository<TMember, TProperty> : NonCachedElementRepository<TMember, TProperty>, IMemberRepository<TMember, TProperty>
        where TMember : IMember<TProperty>
        where TProperty : IProperty {

        /// <inheritdoc/>
        public MemberRepository(IPublishedSnapshotAccessor publishedSnapshotAccessor, IUmbracoContextFactory umbracoContextFactory, IMemberFactory<TMember, TProperty> MemberFactory, ILogger<MemberRepository<TMember, TProperty>> logger) : base(publishedSnapshotAccessor, umbracoContextFactory, MemberFactory, logger) {
            umbracoContextFactory.EnsureUmbracoContext();
        }

        /// <inheritdoc/>
        public virtual TMember? GetMember(Func<IPublishedMemberCache?, IPublishedContent?> fetch, string? culture) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual IEnumerable<TMember?> GetMemberList(Func<IPublishedMemberCache?, IEnumerable<IPublishedContent>?> fetch, string? culture) {
            throw new NotImplementedException();
        }

        /// <inheritdoc/>
        public virtual TMember? GetConvertedMember(IPublishedContent Member, string? culture) {
            return base.GetConvertedElement(Member, culture);
        }
    }
}
