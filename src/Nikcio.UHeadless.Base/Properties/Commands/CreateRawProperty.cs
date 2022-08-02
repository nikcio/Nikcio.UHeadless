using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.Base.Properties.Commands {
    /// <summary>
    /// A command for creating a property
    /// </summary>
    public class CreateRawProperty : CreateProperty {

        /// <inheritdoc/>
        public CreateRawProperty(IProperty property, string? culture, IContentBase contentBase) : base(culture) {
            Property = property;
            ContentBase = contentBase;
        }

        /// <summary>
        /// The property
        /// </summary>
        public IProperty Property { get; }

        /// <summary>
        /// The content
        /// </summary>
        public IContentBase ContentBase { get; }
    }
}
