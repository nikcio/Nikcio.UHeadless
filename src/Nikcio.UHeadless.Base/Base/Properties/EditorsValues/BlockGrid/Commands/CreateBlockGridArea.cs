using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Commands;

/// <summary>
/// Command for creating a block grid item
/// </summary>
public class CreateBlockGridArea : ICommand
{
    /// <inheritdoc/>
    public CreateBlockGridArea(IPublishedContent content, BlockGridArea blockGridArea, string? culture, string? segment, Fallback fallback)
    {
        Content = content;
        BlockGridArea = blockGridArea;
        Culture = culture;
        Segment = segment;
        Fallback = fallback;
    }

    /// <summary>
    /// The <see cref="IPublishedContent"/>
    /// </summary>
    public virtual IPublishedContent Content { get; set; }

    /// <summary>
    /// The <see cref="BlockGridArea"/>
    /// </summary>
    public virtual BlockGridArea BlockGridArea { get; set; }

    /// <summary>
    /// The culture
    /// </summary>
    public virtual string? Culture { get; set; }

    /// <summary>
    /// The segment
    /// </summary>
    public virtual string? Segment { get; set; }

    /// <summary>
    /// The fallback tactic
    /// </summary>
    public virtual Fallback Fallback { get; set; }
}
