using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.BlockGrid;

/// <inheritdoc/>
public class BlockGridAreaModel : BlockGridArea
{
    /// <inheritdoc/>
    public BlockGridAreaModel(CreateBlockGridArea createBlockGridArea, IDependencyReflectorFactory dependencyReflectorFactory) : base(createBlockGridArea)
    {
        Alias = createBlockGridArea.BlockGridArea.Alias;
        RowSpan = createBlockGridArea.BlockGridArea.RowSpan;
        ColumnSpan = createBlockGridArea.BlockGridArea.ColumnSpan;

        Blocks = createBlockGridArea.BlockGridArea?.Select(blockGridItem =>
        {
            var type = typeof(BlockGridItemModel);
            return dependencyReflectorFactory.GetReflectedType<BlockGridItemModel>(type, new object[] { new CreateBlockGridItem(createBlockGridArea.Content, blockGridItem, createBlockGridArea.Culture, createBlockGridArea.Segment, createBlockGridArea.Fallback) });
        }).OfType<BlockGridItemModel>().ToList();
    }

    /// <summary>
    /// Gets the blocks of the block grid area
    /// </summary>
    public virtual List<BlockGridItemModel>? Blocks { get; set; }

    /// <summary>
    /// Gets the alias of the block grid area.
    /// </summary>
    public virtual string? Alias { get; set; }

    /// <summary>
    /// Gets the row dimensions of the block.
    /// </summary>
    public virtual int RowSpan { get; set; }

    /// <summary>
    /// Gets the column dimensions of the block.
    /// </summary>
    public virtual int ColumnSpan { get; set; }
}
