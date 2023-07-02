using Nikcio.UHeadless.Media.TypeModules;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Media.NotificationHandlers;

/// <summary>
/// Triggers GraphQL schema rebuild when media types changes
/// </summary>
public class MediaTypeModuleMediaTypeChangedHandler : INotificationAsyncHandler<MediaTypeChangedNotification>
{
    private readonly MediaTypeModule _mediaTypeModule;

    /// <inheritdoc/>
    public MediaTypeModuleMediaTypeChangedHandler(MediaTypeModule mediaTypeModule)
    {
        _mediaTypeModule = mediaTypeModule;
    }

    public Task HandleAsync(MediaTypeChangedNotification notification, CancellationToken cancellationToken)
    {
        _mediaTypeModule.OnTypesChanged(EventArgs.Empty);

        return Task.CompletedTask;
    }
}