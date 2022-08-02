using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.Base.Properties.Commands {
    /// <summary>
    /// Command for creating a property value
    /// </summary>
    public class CreateRawPropertyValue : CreatePropertyValue {
        /// <inheritdoc/>
        public CreateRawPropertyValue(IContentBase contentBase, IProperty property, string culture) : base(culture) {
            ContentBase = contentBase;
            Property = property;
        }

        /// <summary>
        /// The <see cref="IContentBase"/>
        /// </summary>
        public virtual IContentBase ContentBase { get; set; }

        /// <summary>
        /// The <see cref="IProperty"/>
        /// </summary>
        public virtual IProperty Property { get; set; }
    }
}
