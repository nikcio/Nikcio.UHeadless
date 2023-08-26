using Nikcio.UHeadless.Content.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Content.Composers;

/// <summary>
/// Adds content services
/// </summary>
public class ContentComposer : IComposer
{
    /// <inheritdoc/>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddContentServices();
    }
}
