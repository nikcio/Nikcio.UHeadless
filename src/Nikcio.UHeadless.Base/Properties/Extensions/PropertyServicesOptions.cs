using Nikcio.UHeadless.Base.Properties.Extensions.Options;

namespace Nikcio.UHeadless.Base.Properties.Extensions {
    /// <summary>
    /// Options for the property services
    /// </summary>
    public class PropertyServicesOptions {
        /// <summary>
        /// Options for the property map
        /// </summary>
        public virtual PropertyMapOptions PropertyMapOptions { get; set; } = new();
    }
}
