namespace Nikcio.UHeadless.Content.EventMessages;

/// <summary>
/// Represents a content created event message
/// </summary>
public class ContentCreatedSingleEventMessage
{
    /// <inheritdoc/>
    public ContentCreatedSingleEventMessage(int contentId, string? editedCulture)
    {
        ContentId = contentId;
        EditedCulture = editedCulture;
    }

    /// <summary>
    /// The content id
    /// </summary>
    public int ContentId { get; }

    /// <summary>
    /// The edited culture
    /// </summary>
    public string? EditedCulture { get; }
}
