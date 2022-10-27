using Nikcio.UHeadless.Umbraco.Forms.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Umbraco.Forms.Composers;

/// <summary>
/// Composes services for Nikcio.UHeadless.Umbraco.Forms
/// </summary>
public class UmbracoFormsComposer : IComposer
{
    /// <inheritdoc/>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddUmbracoFormsServices();
    }
}
