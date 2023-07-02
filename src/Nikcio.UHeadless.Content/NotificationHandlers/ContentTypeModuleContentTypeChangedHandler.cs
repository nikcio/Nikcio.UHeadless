using Nikcio.UHeadless.Content.TypeModules;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Content.NotificationHandlers;

/// <summary>
/// Triggers GraphQL schema rebuild when content types changes
/// </summary>
public class ContentTypeModuleContentTypeChangedHandler : INotificationAsyncHandler<ContentTypeChangedNotification>
{
    private readonly ContentTypeModule _contentTypeModule;

    /// <inheritdoc/>
    public ContentTypeModuleContentTypeChangedHandler(ContentTypeModule contentTypeModule)
    {
        _contentTypeModule = contentTypeModule;
    }

    /// <inheritdoc/>
    public Task HandleAsync(ContentTypeChangedNotification notification, CancellationToken cancellationToken)
    {
        _contentTypeModule.OnTypesChanged(EventArgs.Empty);

        return Task.CompletedTask;
    }
}