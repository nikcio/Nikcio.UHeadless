using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockGrid.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Creation.Models.Example.Properties;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.BlockGrid;

/// <inheritdoc/>
public class BlockGridItemModel : BlockGridItem
{
    /// <inheritdoc/>
    public BlockGridItemModel(CreateBlockGridItem createBlockGridItem, IPropertyFactory<PropertyModel> propertyFactory, IDependencyReflectorFactory dependencyReflectorFactory) : base(createBlockGridItem)
    {
        if (createBlockGridItem.BlockGridItem == null)
        {
            return;
        }
        if (createBlockGridItem.Content != null)
        {
            ContentAlias = createBlockGridItem.BlockGridItem.Content.ContentType?.Alias;
            foreach (var property in createBlockGridItem.BlockGridItem.Content.Properties)
            {
                PropertyModel? propertyModel = propertyFactory.GetProperty(property, createBlockGridItem.Content, createBlockGridItem.Culture, createBlockGridItem.Segment, createBlockGridItem.Fallback);

                if (propertyModel == null)
                {
                    continue;
                }

                ContentProperties.Add(propertyModel.Alias, propertyModel);
            }

            if (createBlockGridItem.BlockGridItem.Settings != null)
            {
                SettingsAlias = createBlockGridItem.BlockGridItem.Settings.ContentType?.Alias;
                foreach (var property in createBlockGridItem.BlockGridItem.Settings.Properties)
                {
                    PropertyModel? propertyModel = propertyFactory.GetProperty(property, createBlockGridItem.Content, createBlockGridItem.Culture, createBlockGridItem.Segment, createBlockGridItem.Fallback);

                    if (propertyModel == null)
                    {
                        continue;
                    }

                    SettingsProperties.Add(propertyModel.Alias, propertyModel);
                }
            }

            if (createBlockGridItem.BlockGridItem.Areas != null)
            {
                foreach (var area in createBlockGridItem.BlockGridItem.Areas)
                {
                    var createBlockGridArea = new CreateBlockGridArea(createBlockGridItem.Content, area, createBlockGridItem.Culture, createBlockGridItem.Segment, createBlockGridItem.Fallback);
                    Areas.Add(dependencyReflectorFactory.GetReflectedType<BlockGridAreaModel>(typeof(BlockGridAreaModel), new object[] { createBlockGridArea }));
                }
            }

            RowSpan = createBlockGridItem.BlockGridItem.RowSpan;

            ColumnSpan = createBlockGridItem.BlockGridItem.ColumnSpan;
        }
    }

    /// <inheritdoc/>
    public virtual Dictionary<string, PropertyModel?> ContentProperties { get; set; } = new();

    /// <inheritdoc/>
    public virtual Dictionary<string, PropertyModel?> SettingsProperties { get; set; } = new();

    /// <summary>
    /// Gets the alias of the content block grid item.
    /// </summary>
    public virtual string? ContentAlias { get; set; }

    /// <summary>
    /// Gets the alias of the settings block grid item.
    /// </summary>
    public virtual string? SettingsAlias { get; set; }

    /// <summary>
    /// Gets the areas of the block grid item.
    /// </summary>
    public virtual List<BlockGridAreaModel?> Areas { get; set; } = new();

    /// <summary>
    /// Gets the row dimensions of the block.
    /// </summary>
    public virtual int RowSpan { get; set; }

    /// <summary>
    /// Gets the column dimensions of the block.
    /// </summary>
    public virtual int ColumnSpan { get; set; }
}