using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.Fallback;

/// <summary>
/// Represents an unsupported property value
/// </summary>
public class UnsupportedPropertyModel : PropertyValue
{
    /// <summary>
    /// Gets the message of the property
    /// </summary>
    public virtual string Message { get; set; }

    /// <inheritdoc/>
    public UnsupportedPropertyModel(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
    {
        Message = $"{createPropertyValue.Property.PropertyType.EditorAlias} is not supported in UHeadless by default. Create your own implementation to use this editor.";
    }
}
