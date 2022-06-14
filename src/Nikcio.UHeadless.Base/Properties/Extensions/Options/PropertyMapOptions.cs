using Nikcio.UHeadless.Base.Properties.Maps;

namespace Nikcio.UHeadless.Base.Properties.Extensions.Options {
    /// <summary>
    /// Options for the property map
    /// </summary>
    public class PropertyMapOptions {
        /// <summary>
        /// Any custom mappings of properties
        /// </summary>
        public virtual List<Action<IPropertyMap>>? PropertyMappings { get; set; }

        /// <summary>
        /// The property map
        /// </summary>
        /// <remarks>
        /// This will be used to create the singleton
        /// </remarks>
        public virtual IPropertyMap PropertyMap { get; set; } = new PropertyMap();
    }
}
