using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.Grid.Commands {
    /// <summary>
    /// A command to create a grid element
    /// </summary>
    public class CreateGridElement : ICommand {
        /// <inheritdoc/>
        public CreateGridElement(IPublishedContent content, GridValue gridValue, string culture) {
            Content = content;
            GridValue = gridValue;
            Culture = culture;
        }

        /// <summary>
        /// The <see cref="IPublishedContent"/>
        /// </summary>
        public virtual IPublishedContent Content { get; set; }

        /// <summary>
        /// The <see cref="GridValue"/>
        /// </summary>
        public virtual GridValue GridValue { get; set; }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string Culture { get; set; }
    }
}
