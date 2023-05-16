using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.ContentPicker.Commands;

/// <summary>
/// A command for creating a content picker item
/// </summary>
public class CreateContentPickerItem : ICommand
{
    /// <inheritdoc/>
    public CreateContentPickerItem(IPublishedContent publishedContent, IVariationContextAccessor variationContextAccessor, string? culture)
    {
        PublishedContent = publishedContent;
        VariationContextAccessor = variationContextAccessor;
        Culture = culture;
    }

    /// <summary>
    /// The published content
    /// </summary>
    public virtual IPublishedContent PublishedContent { get; set; }

    /// <summary>
    /// The variation context accessor
    /// </summary>
    public virtual IVariationContextAccessor VariationContextAccessor { get; set; }

    /// <summary>
    /// The culture
    /// </summary>
    public virtual string? Culture { get; set; }
}
