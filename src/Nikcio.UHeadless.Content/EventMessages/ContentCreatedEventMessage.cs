namespace Nikcio.UHeadless.Content.EventMessages;

/// <summary>
/// Represents a content created event message with multiple content items
/// </summary>
public class ContentCreatedEventMessage
{
    /// <inheritdoc/>
    public ContentCreatedEventMessage(List<ContentCreatedSingleEventMessage> eventMessages)
    {
        EventMessages = eventMessages;
    }

    /// <summary>
    /// The event messages
    /// </summary>
    public List<ContentCreatedSingleEventMessage> EventMessages { get; }
}
