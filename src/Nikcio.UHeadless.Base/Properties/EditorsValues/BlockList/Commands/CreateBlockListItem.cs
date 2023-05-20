using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Commands;

/// <summary>
/// Command for creating a block list item
/// </summary>
public class CreateBlockListItem : ICommand
{
    /// <inheritdoc/>
    public CreateBlockListItem(IPublishedContent content, BlockListItem blockListItem, string? culture, string? segment, Fallback fallback)
    {
        Content = content;
        BlockListItem = blockListItem;
        Culture = culture;
        Segment = segment;
        Fallback = fallback;
    }

    /// <summary>
    /// The <see cref="IPublishedContent"/>
    /// </summary>
    public virtual IPublishedContent Content { get; set; }

    /// <summary>
    /// The <see cref="BlockListItem"/>
    /// </summary>
    public virtual BlockListItem BlockListItem { get; set; }

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
