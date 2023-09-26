using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Creation.Models.Example.Properties;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.BlockList;

/// <inheritdoc/>
public class BlockListItemModel : BlockListItem
{
    /// <inheritdoc/>
    public BlockListItemModel(CreateBlockListItem createBlockListItem, IPropertyFactory<PropertyModel> propertyFactory) : base(createBlockListItem)
    {
        if (createBlockListItem.BlockListItem == null)
        {
            return;
        }
        if (createBlockListItem.Content != null)
        {
            ContentAlias = createBlockListItem.BlockListItem.Content.ContentType?.Alias;
            foreach (var property in createBlockListItem.BlockListItem.Content.Properties)
            {
                PropertyModel? propertyModel = propertyFactory.GetProperty(property, createBlockListItem.Content, createBlockListItem.Culture, createBlockListItem.Segment, createBlockListItem.Fallback);

                if (propertyModel == null)
                {
                    continue;
                }

                ContentProperties.Add(propertyModel.Alias, propertyModel);
            }

            if (createBlockListItem.BlockListItem.Settings != null)
            {
                SettingsAlias = createBlockListItem.BlockListItem.Settings.ContentType?.Alias;
                foreach (var property in createBlockListItem.BlockListItem.Settings.Properties)
                {
                    PropertyModel? propertyModel = propertyFactory.GetProperty(property, createBlockListItem.Content, createBlockListItem.Culture, createBlockListItem.Segment, createBlockListItem.Fallback);

                    if (propertyModel == null)
                    {
                        continue;
                    }

                    SettingsProperties.Add(propertyModel.Alias, propertyModel);
                }
            }
        }
    }

    /// <inheritdoc/>
    public virtual Dictionary<string, PropertyModel?> ContentProperties { get; set; } = new();

    /// <inheritdoc/>
    public virtual Dictionary<string, PropertyModel?> SettingsProperties { get; set; } = new();

    /// <summary>
    /// Gets the alias of the content block list item.
    /// </summary>
    public virtual string? ContentAlias { get; set; }

    /// <summary>
    /// Gets the alias of the settings block list item.
    /// </summary>
    public virtual string? SettingsAlias { get; set; }
}