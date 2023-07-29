using HotChocolate.Subscriptions;
using Nikcio.UHeadless.Content.EventMessages;
using Nikcio.UHeadless.Core.Constants;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Content.NotificationHandlers;

/// <summary>
/// The default notification handler for the ContentCreated subscription
/// </summary>
/// <remarks>
/// This makes sure to send the correct payload to the appropiate topic
/// </remarks>
public class ContentCreatedSubscriptionHandler : INotificationAsyncHandler<ContentSavedNotification>
{
    private readonly ITopicEventSender _topicEventSender;

    /// <inheritdoc/>
    public ContentCreatedSubscriptionHandler(ITopicEventSender topicEventSender)
    {
        _topicEventSender = topicEventSender;
    }

    /// <inheritdoc/>
    public async Task HandleAsync(ContentSavedNotification notification, CancellationToken cancellationToken)
    {
        var eventMessages = new List<ContentCreatedSingleEventMessage>();
        foreach (var entity in notification.SavedEntities)
        {
            var isNew = entity.WasPropertyDirty("Id");
            if (!isNew)
            {
                continue;
            }

            if (entity.EditedCultures == null)
            {
                eventMessages.Add(new ContentCreatedSingleEventMessage(entity.Id, null));
            } 
            else
            {
                foreach (var culture in entity.EditedCultures)
                {
                    eventMessages.Add(new ContentCreatedSingleEventMessage(entity.Id, culture));
                }
            }
        }

        await _topicEventSender.SendAsync(SubscriptionTopics.Content.ContentCreated, new ContentCreatedEventMessage(eventMessages), cancellationToken).ConfigureAwait(false);
    }
}
