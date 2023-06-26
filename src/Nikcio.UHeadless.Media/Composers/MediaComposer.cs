using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Media.Extensions;
using Nikcio.UHeadless.Media.NotificationHandlers;
using Nikcio.UHeadless.Media.TypeModules;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

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

        builder.AddNotificationAsyncHandler<MediaTypeChangedNotification, MediaTypeModuleMediaTypeChangedHandler>();
        builder.Services.AddSingleton<MediaTypeModule>();
    }
}
