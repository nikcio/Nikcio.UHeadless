using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.MultiUrlPicker.Commands {
    /// <summary>
    /// A command to create a link for a multi url picker
    /// </summary>
    public class CreateMultiUrlPickerItem : ICommand {
        /// <inheritdoc/>
        public CreateMultiUrlPickerItem(Link umbracoLink) {
            UmbracoLink = umbracoLink;
        }

        /// <summary>
        /// The umbraco link model
        /// </summary>
        public Link UmbracoLink { get; }
    }
}
