using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Commands {

    public class CreateBasicGridElement : ICommand {
        /// <inheritdoc/>
        public CreateBasicGridElement(IPublishedContent content, GridValue blockListItem, string culture) {
            Content = content;
            BlockListItem = blockListItem;
            Culture = culture;
        }

        /// <summary>
        /// The <see cref="IPublishedContent"/>
        /// </summary>
        public virtual IPublishedContent Content { get; set; }

        /// <summary>
        /// The <see cref="BlockListItem"/>
        /// </summary>
        public virtual GridValue BlockListItem { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string Culture { get; set; }
    }
}
