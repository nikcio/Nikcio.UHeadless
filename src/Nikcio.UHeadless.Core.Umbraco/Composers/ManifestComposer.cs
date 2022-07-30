using Nikcio.UHeadless.Core.Umbraco.ManifestFilters;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Core.Umbraco.Composers {
    /// <summary>
    /// Composes the manifest information
    /// </summary>
    public class ManifestComposer : IComposer {
        /// <inheritdoc/>
        public void Compose(IUmbracoBuilder builder) {
            builder.ManifestFilters().Append<UHeadlessManifestFilter>();
        }
    }
}
