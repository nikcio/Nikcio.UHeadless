using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Members.Commands;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Members.Basics.Models {
    /// <summary>
    /// Represents a member
    /// </summary>
    public class BasicMember : Member<BasicProperty> {
        /// <inheritdoc/>
        public BasicMember(CreateMember createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory) {
        }

        /// <summary>
        /// The member id
        /// </summary>
        [GraphQLDescription("The member id")]
        public int? Id => MemberItem?.Id;

        /// <summary>
        /// The member parent id
        /// </summary>
        [GraphQLDescription("The member parent id")]
        public int? ParentId => MemberItem?.Parent.Id;

        /// <summary>
        /// The member content type id
        /// </summary>
        [GraphQLDescription("The member content type id")]
        public int? ContentTypeId => MemberItem?.ContentType.Id;

        /// <summary>
        /// The member content type alias
        /// </summary>
        [GraphQLDescription("The member content type alias")]
        public string? ContentTypeAlias => MemberItem?.ContentType.Alias;

        /// <summary>
        /// The member create date
        /// </summary>
        [GraphQLDescription("The member create date")]
        public DateTime? CreateDate => MemberItem?.CreateDate;

        /// <summary>
        /// The member creator id
        /// </summary>
        [GraphQLDescription("The member creator id")]
        public int? CreatorId => MemberItem?.CreatorId;

        /// <summary>
        /// The member email
        /// </summary>
        //[GraphQLDescription("The member email")]
        //public string? Email => MemberItem?.Value(Constants.Conventions.Member.);

        /// <summary>
        /// The member email confirmed date
        /// </summary>
        [GraphQLDescription("The member email confirmed date")]
        public DateTime? EmailConfirmedDate => MemberItem?.EmailConfirmedDate;

        /// <summary>
        /// The member failed password attempts
        /// </summary>
        [GraphQLDescription("The member failed password attempts")]
        public int? FailedPasswordAttempts => MemberItem?.FailedPasswordAttempts;

        /// <summary>
        /// The member has additionalData
        /// </summary>
        [GraphQLDescription("The member has additionalData")]
        public bool? HasAdditionalData => MemberItem?.HasAdditionalData;

        /// <summary>
        /// The member has identity
        /// </summary>
        [GraphQLDescription("The member has identity")]
        public bool? HasIdentity => MemberItem?.HasIdentity;

        /// <summary>
        /// The member is approved
        /// </summary>
        [GraphQLDescription("The member is approved")]
        public bool? IsApproved => MemberItem?.IsApproved;

        /// <summary>
        /// The member delete date
        /// </summary>
        [GraphQLDescription("The member delete date")]
        public DateTime? DeleteDate => MemberItem?.DeleteDate;

        /// <summary>
        /// The member is locked out
        /// </summary>
        [GraphQLDescription("The member is locked out")]
        public bool? IsLockedOut => MemberItem?.IsLockedOut;

        /// <summary>
        /// The member key
        /// </summary>
        [GraphQLDescription("The member key")]
        public Guid? Key => MemberItem?.Key;

        /// <summary>
        /// The member last lockout date
        /// </summary>
        [GraphQLDescription("The member last lockout date")]
        public DateTime? LastLockoutDate => MemberItem?.LastLockoutDate;

        /// <summary>
        /// The member last login date
        /// </summary>
        [GraphQLDescription("The member last login date")]
        public DateTime? LastLoginDate => MemberItem?.LastLoginDate;

        /// <summary>
        /// The member last password change date
        /// </summary>
        [GraphQLDescription("The member last password change date")]
        public DateTime? LastPasswordChangeDate => MemberItem?.LastPasswordChangeDate;

        /// <summary>
        /// The member level
        /// </summary>
        [GraphQLDescription("The member level")]
        public int? Level => MemberItem?.Level;

        /// <summary>
        /// The member name
        /// </summary>
        [GraphQLDescription("The member name")]
        public string? Name => MemberItem?.Name;

        /// <summary>
        /// The members password configuration
        /// </summary>
        [GraphQLDescription("The members password configuration")]
        public string? PasswordConfiguration => MemberItem?.PasswordConfiguration;

        /// <summary>
        /// The members path
        /// </summary>
        [GraphQLDescription("The members path")]
        public string? Path => MemberItem?.Path;

        /// <summary>
        /// The members properties
        /// </summary>
        [GraphQLDescription("The members properties")]
        public virtual IEnumerable<BasicProperty?>? Properties => MemberItem != null ? PropertyFactory.CreateProperties(MemberItem, Culture) : default;

        /// <summary>
        /// The member raw password value
        /// </summary>
        [GraphQLDescription("The member raw password value")]
        public string? RawPasswordValue => MemberItem?.RawPasswordValue;

        /// <summary>
        /// The members security stamp
        /// </summary>
        [GraphQLDescription("The members security stamp")]
        public string? SecurityStamp => MemberItem?.SecurityStamp;

        /// <summary>
        /// The member sort order
        /// </summary>
        [GraphQLDescription("The member sort order")]
        public int? SortOrder => MemberItem?.SortOrder;

        /// <summary>
        /// Is the member trashed
        /// </summary>
        [GraphQLDescription("Is the member trashed")]
        public bool? Trashed => MemberItem?.Trashed;

        /// <summary>
        /// The member username
        /// </summary>
        [GraphQLDescription("The member username")]
        public string? Username => MemberItem?.Username;

        /// <summary>
        /// The member writer id
        /// </summary>
        [GraphQLDescription("The member writer id")]
        public int? WriterId => MemberItem?.WriterId;
    }
}
