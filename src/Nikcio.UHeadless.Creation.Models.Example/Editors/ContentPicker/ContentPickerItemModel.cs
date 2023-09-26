using Nikcio.UHeadless.Base.Properties.EditorsValues.ContentPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.ContentPicker.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.ContentPicker;

/// <summary>
/// Represents a content picker item
/// </summary>
public class ContentPickerItemModel : ContentPickerItem
{
    /// <inheritdoc/>
    public ContentPickerItemModel(CreateContentPickerItem createContentPickerItem) : base(createContentPickerItem)
    {
        Content = createContentPickerItem.PublishedContent;
        VariationContextAccessor = createContentPickerItem.VariationContextAccessor;

        Id = Content.Id;
        Url = Content.Url(Culture, UrlMode.Default);
        AbsoluteUrl = Content.Url(Culture, UrlMode.Absolute);
        Name = Content.Name(VariationContextAccessor, Culture);
    }

    /// <summary>
    /// Gets the id of a content item
    /// </summary>
    public virtual int Id { get; }

    /// <summary>
    /// Gets the url of a content item
    /// </summary>
    public virtual string Url { get; }

    /// <summary>
    /// Gets the absolute url of a content item
    /// </summary>
    public virtual string AbsoluteUrl { get; }

    /// <summary>
    /// Gets the name of a content item
    /// </summary>
    public virtual string? Name { get; }

    /// <summary>
    /// The <see cref="IPublishedContent"/>
    /// </summary>
    protected virtual IPublishedContent Content { get; set; }

    /// <summary>
    /// The variation context accessor
    /// </summary>
    protected virtual IVariationContextAccessor VariationContextAccessor { get; set; }

    /// <summary>
    /// The culture
    /// </summary>
    protected virtual string? Culture { get; set; }
}
