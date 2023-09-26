using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.BlockGrid;

/// <summary>
/// Represents a block grid model
/// </summary>
public class BlockGridModel : PropertyValue
{
    /// <summary>
    /// Gets the blocks of a block grid model
    /// </summary>
    public virtual List<BlockGridItem>? Blocks { get; set; }

    /// <summary>
    /// Gets the number of columns defined for the grid
    /// </summary>
    public virtual int? GridColumns { get; set; }

    /// <inheritdoc/>
    public BlockGridModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
    {
        var propertyValue = createPropertyValue.Property.Value<Umbraco.Cms.Core.Models.Blocks.BlockGridModel>(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);

        Blocks = propertyValue?.Select(blockGridItem =>
        {
            var type = typeof(BlockGridItem);
            return dependencyReflectorFactory.GetReflectedType<BlockGridItem>(type, new object[] { new CreateBlockGridItem(createPropertyValue.Content, blockGridItem, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback) });
        }).OfType<BlockGridItem>().ToList();

        GridColumns = propertyValue?.GridColumns;
    }
}
