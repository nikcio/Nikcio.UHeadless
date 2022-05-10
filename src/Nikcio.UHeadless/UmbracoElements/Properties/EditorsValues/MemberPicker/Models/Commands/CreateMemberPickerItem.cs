using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models.Commands {
    /// <summary>
    /// A command to create a member
    /// </summary>
    public class CreateMemberPickerItem {
        /// <inheritdoc/>
        public CreateMemberPickerItem(CreatePropertyValue createPropertyValue, IPublishedContent member) {
            CreatePropertyValue = createPropertyValue;
            Member = member;
        }

        /// <summary>
        /// A command for creating a property
        /// </summary>
        public CreatePropertyValue CreatePropertyValue { get; }

        /// <summary>
        /// The member
        /// </summary>
        public IPublishedContent Member { get; }
    }
}
