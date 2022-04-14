using System;
using System.Collections.Generic;
using Nikcio.UHeadless.UmbracoElements.Properties.Maps;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Extensions.Options {
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
