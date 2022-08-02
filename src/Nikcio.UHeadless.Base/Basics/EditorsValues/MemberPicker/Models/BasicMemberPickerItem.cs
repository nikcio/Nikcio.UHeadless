using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MemberPicker.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a member item.")]
    public class BasicMemberPickerItem : BasicMemberPickerItem<BasicProperty> {
        /// <inheritdoc/>
        public BasicMemberPickerItem(CreateMemberPickerItem createMember, IPropertyFactory<BasicProperty> propertyFactory, IUmbracoContextAccessor umbracoContextAccessor) : base(createMember, propertyFactory, umbracoContextAccessor) {
        }
    }

    /// <inheritdoc/>
    [GraphQLDescription("Represents a member item.")]
    public class BasicMemberPickerItem<TProperty> : MemberPickerItem
        where TProperty : Base.Properties.Models.IProperty {
        /// <inheritdoc/>
        public BasicMemberPickerItem(CreateMemberPickerItem createMember, IPropertyFactory<TProperty> propertyFactory, IUmbracoContextAccessor umbracoContextAccessor) : base(createMember) {
            if (createMember.Member == null) {
                return;
            }

            Id = createMember.Member.Id;
            Name = createMember.Member.Name;
            if (createMember.Member.Properties != null) {
                foreach (var property in createMember.Member.Properties) {
                    if(createMember.CreatePropertyValue is CreatePublishedPropertyValue createPublishedPropertyValue) {
                        Properties.Add(propertyFactory.GetProperty(property, createPublishedPropertyValue.Content, createMember.CreatePropertyValue.Culture));
                    } else if(createMember.CreatePropertyValue is CreateRawPropertyValue createRawPropertyValue) {
                        if(umbracoContextAccessor.TryGetUmbracoContext(out var umbracoContext)) {
                            IPublishedContent? publishedContent = GetPublishedContent(umbracoContext, createRawPropertyValue);
                            if (publishedContent != null) {
                                Properties.Add(propertyFactory.GetProperty(property, publishedContent, createMember.CreatePropertyValue.Culture));
                                continue;
                            }
                        }

                        if (createRawPropertyValue.ContentBase is IMember member) {
                            throw new NotImplementedException(); //TODO
                        }
                    }
                }
            }
        }

        private static IPublishedContent? GetPublishedContent(IUmbracoContext umbracoContext, CreateRawPropertyValue createRawPropertyValue) {
            IPublishedContent? publishedContent = default;
            if (createRawPropertyValue.ContentBase is IContent contentItem) {
                publishedContent = umbracoContext.Content?.GetById(contentItem.Id);
            } else if (createRawPropertyValue.ContentBase is IMedia media) {
                publishedContent = umbracoContext.Media?.GetById(media.Id);
            }

            return publishedContent;
        }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the id of the member.")]
        public virtual int? Id { get; set; }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the name of a member.")]
        public virtual string? Name { get; set; }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of a member.")]
        public virtual List<TProperty?> Properties { get; set; } = new();
    }
}
