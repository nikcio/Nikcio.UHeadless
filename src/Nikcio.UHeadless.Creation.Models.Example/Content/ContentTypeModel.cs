using Nikcio.UHeadless.ContentTypes.Commands;
using Nikcio.UHeadless.ContentTypes.Models;

namespace Nikcio.UHeadless.Creation.Models.Example.Content;

/// <summary>
/// Represents a content type
/// </summary>
public class ContentTypeModel : ContentType
{
    /// <inheritdoc/>
    public ContentTypeModel(CreateContentType createContentType) : base(createContentType)
    {
        Id = createContentType.PublishedContentType.Id;
        Alias = createContentType.PublishedContentType.Alias;
    }

    /// <summary>
    /// Gets the content type identifier
    /// </summary>
    public virtual int Id { get; }

    /// <summary>
    /// Gets the content type alias
    /// </summary>
    public virtual string? Alias { get; }
}
