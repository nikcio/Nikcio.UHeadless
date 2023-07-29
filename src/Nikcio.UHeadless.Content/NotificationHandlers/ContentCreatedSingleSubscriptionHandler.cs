using HotChocolate.Subscriptions;
using Nikcio.UHeadless.Content.EventMessages;
using Nikcio.UHeadless.Core.Constants;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Content.NotificationHandlers;

/// <summary>
/// The default notification handler for the ContentCreatedSingle subscription
/// </summary>
/// <remarks>
/// This makes sure to send the correct payload to the appropiate topic
/// </remarks>
public class ContentCreatedSingleSubscriptionHandler : INotificationAsyncHandler<ContentSavedNotification>
{
    private readonly ITopicEventSender _topicEventSender;

    /// <inheritdoc/>
    public ContentCreatedSingleSubscriptionHandler(ITopicEventSender topicEventSender)
    {
        _topicEventSender = topicEventSender;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(ContentSavedNotification notification, CancellationToken cancellationToken)
    {
        foreach (var entity in notification.SavedEntities)
        {
            var isNew = entity.WasPropertyDirty("Id");
            if (!isNew)
            {
                continue;
            }

            if (entity.EditedCultures == null || !entity.EditedCultures.Any())
            {
                await _topicEventSender.SendAsync(SubscriptionTopics.Content.ContentCreatedSingle, new ContentCreatedSingleEventMessage(entity.Id, null), cancellationToken).ConfigureAwait(false);
            } 
            else
            {
                foreach (var culture in entity.EditedCultures)
                {
                    await _topicEventSender.SendAsync(SubscriptionTopics.Content.ContentCreatedSingle, new ContentCreatedSingleEventMessage(entity.Id, culture), cancellationToken).ConfigureAwait(false);
                }
            }
        }
    }
}
