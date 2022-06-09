using Nikcio.UHeadless.Properties.Maps;

namespace Nikcio.UHeadless.Properties.Extensions.Options {
    /// <summary>
    /// Options for the property map
    /// </summary>
    public class PropertyMapOptions {
        /// <summary>
        /// Any custom mappings of properties
        /// </summary>
        public virtual List<Action<IPropertyMap>>? PropertyMappings { get; set; }
    }
}
