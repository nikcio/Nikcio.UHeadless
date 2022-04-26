using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models {
    /// <summary>
    /// A member for a member picker
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    public class MemberItem<TProperty>
        where TProperty : IProperty {
        /// <inheritdoc/>
        public MemberItem(CreateMemberPickerItem<TProperty> _) {

        }
    }
}
