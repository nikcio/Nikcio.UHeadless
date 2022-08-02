using Nikcio.UHeadless.Core.Commands;

namespace Nikcio.UHeadless.Base.Properties.Commands {
    /// <summary>
    /// A command for creating a property
    /// </summary>
    public class CreateProperty : ICommand {
        /// <inheritdoc/>
        public CreateProperty(string? culture) {
            Culture = culture;
        }

        /// <summary>
        /// The culture
        /// </summary>
        public string? Culture { get; }
    }
}
