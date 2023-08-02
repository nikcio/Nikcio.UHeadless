using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Base.Composers;

/// <summary>
/// A composer for UHeadless internals.
/// </summary>
public interface IUHeadlessComposer : IDiscoverable
{
    /// <summary>
    /// Compose.
    /// </summary>
    void Compose(IUmbracoBuilder builder);
}
