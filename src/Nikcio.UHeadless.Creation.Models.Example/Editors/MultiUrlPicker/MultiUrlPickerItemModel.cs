using Nikcio.UHeadless.Base.Properties.EditorsValues.MultiUrlPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MultiUrlPicker.Models;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.MultiUrlPicker;

/// <summary>
/// Represents a link item
/// </summary>
public class MultiUrlPickerItemModel : MultiUrlPickerItem
{
    /// <summary>
    /// Gets the name of the lin
    /// </summary>
    public virtual string? Name { get; set; }

    /// <summary>
    /// Gets the target of the link
    /// </summary>
    public virtual string? Target { get; set; }

    /// <summary>
    /// Gets the type of the link
    /// </summary>
    public virtual LinkType Type { get; set; }

    /// <summary>
    /// Gets the url of a link
    /// </summary>
    public virtual string? Url { get; set; }

    /// <inheritdoc/>
    public MultiUrlPickerItemModel(CreateMultiUrlPickerItem createLink) : base(createLink)
    {
        Name = createLink.UmbracoLink.Name;
        Target = createLink.UmbracoLink.Target;
        Type = createLink.UmbracoLink.Type;
        Url = createLink.UmbracoLink.Url;
    }
}