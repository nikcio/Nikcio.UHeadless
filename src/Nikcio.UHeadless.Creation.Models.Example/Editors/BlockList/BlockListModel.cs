using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.BlockList;

/// <summary>
/// Represents a block list model
/// </summary>
public class BlockListModel : PropertyValue
{
    /// <summary>
    /// Gets the blocks of a block list model
    /// </summary>
    public virtual List<BlockListItemModel>? Blocks { get; set; }

    /// <inheritdoc/>
    public BlockListModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
    {
        var propertyValue = createPropertyValue.Property.Value<Umbraco.Cms.Core.Models.Blocks.BlockListModel>(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);

        Blocks = propertyValue?.Select(blockListItem =>
        {
            var type = typeof(BlockListItemModel);
            return dependencyReflectorFactory.GetReflectedType<BlockListItemModel>(type, new object[] { new CreateBlockListItem(createPropertyValue.Content, blockListItem, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback) });
        }).OfType<BlockListItemModel>().ToList();
    }
}
