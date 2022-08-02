using Nikcio.UHeadless.Core.Commands;

namespace Nikcio.UHeadless.Base.Properties.Commands {
    /// <summary>
    /// Command for creating a property value
    /// </summary>
    public class CreatePropertyValue : ICommand {
        /// <inheritdoc/>
        public CreatePropertyValue(string culture) {
            Culture = culture;
        }

        /// <summary>
        /// The culture
        /// </summary>
        public virtual string Culture { get; set; }
    }
}
