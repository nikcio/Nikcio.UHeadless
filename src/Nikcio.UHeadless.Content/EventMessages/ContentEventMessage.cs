namespace Nikcio.UHeadless.Content.EventMessages;

/// <summary>
/// Represents a content event message
/// </summary>
public class ContentEventMessage
{
    /// <inheritdoc/>
    public ContentEventMessage(int contentId)
    {
        ContentId = contentId;
    }

    /// <summary>
    /// The content id
    /// </summary>
    public int ContentId { get; set; }
}