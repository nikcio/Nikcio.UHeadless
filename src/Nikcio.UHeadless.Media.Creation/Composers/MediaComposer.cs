using Nikcio.UHeadless.Media.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Media.Composers;

/// <summary>
/// Adds media services
/// </summary>
public class MediaComposer : IComposer
{
    /// <inheritdoc/>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddMediaServices();
    }
}
