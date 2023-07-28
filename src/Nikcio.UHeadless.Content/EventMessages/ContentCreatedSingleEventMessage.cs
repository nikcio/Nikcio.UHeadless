namespace Nikcio.UHeadless.Content.EventMessages;

/// <summary>
/// Represents a content created event message
/// </summary>
public class ContentCreatedSingleEventMessage : ContentEventMessage
{
    /// <inheritdoc/>
    public ContentCreatedSingleEventMessage(int contentId, string? editedCulture) : base(contentId)
    {
        EditedCulture = editedCulture;
    }

    /// <summary>
    /// The edited culture
    /// </summary>
    public string? EditedCulture { get; set; }
}
