using HotChocolate;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.BlockList.Models;

/// <inheritdoc/>
[GraphQLDescription("Represents a block list item.")]
public class BasicBlockListItem : BasicBlockListItem<BasicProperty>
{
    /// <inheritdoc/>
    public BasicBlockListItem(CreateBlockListItem createBlockListItem, IPropertyFactory<BasicProperty> propertyFactory) : base(createBlockListItem, propertyFactory)
    {
    }
}

/// <inheritdoc/>
[GraphQLDescription("Represents a block list item.")]
public class BasicBlockListItem<TProperty> : BlockListItem
    where TProperty : IProperty
{
    /// <inheritdoc/>
    public BasicBlockListItem(CreateBlockListItem createBlockListItem, IPropertyFactory<TProperty> propertyFactory) : base(createBlockListItem)
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
                ContentProperties.Add(propertyFactory.GetProperty(property, createBlockListItem.Content, createBlockListItem.Culture));
            }

            if (createBlockListItem.BlockListItem.Settings != null)
            {
                SettingsAlias = createBlockListItem.BlockListItem.Settings.ContentType?.Alias;
                foreach (var property in createBlockListItem.BlockListItem.Settings.Properties)
                {
                    SettingsProperties.Add(propertyFactory.GetProperty(property, createBlockListItem.Content, createBlockListItem.Culture));
                }
            }
        }
    }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the content properties of the block list item.")]
    public virtual List<TProperty?> ContentProperties { get; set; } = new();

    /// <inheritdoc/>
    [GraphQLDescription("Gets the setting properties of the block list item.")]
    public virtual List<TProperty?> SettingsProperties { get; set; } = new();

    /// <summary>
    /// Gets the alias of the content block list item.
    /// </summary>
    [GraphQLDescription("Gets the alias of the content block list item.")]
    public virtual string? ContentAlias { get; set; }

    /// <summary>
    /// Gets the alias of the settings block list item.
    /// </summary>
    [GraphQLDescription("Gets the alias of the settings block list item.")]
    public virtual string? SettingsAlias { get; set; }
}