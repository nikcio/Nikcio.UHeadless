using Nikcio.UHeadless.UmbracoRegistration.ManifestFilters;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.UmbracoRegistration.Composers;

/// <summary>
/// Composes the manifest information
/// </summary>
public class ManifestComposer : IComposer
{
    /// <inheritdoc/>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ManifestFilters().Append<UHeadlessManifestFilter>();
    }
}
