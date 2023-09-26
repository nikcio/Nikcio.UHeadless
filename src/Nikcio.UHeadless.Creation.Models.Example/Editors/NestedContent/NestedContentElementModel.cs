using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Creation.Models.Example.Properties;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.NestedContent;

/// <summary>
/// Represents nested content
/// </summary>
public class NestedContentElementModel : NestedContentElement
{
    /// <summary>
    /// Gets the properties of the nested content
    /// </summary>
    public virtual List<PropertyModel?> Properties { get; set; } = new();

    /// <inheritdoc/>
    public NestedContentElementModel(CreateNestedContentElement createElement, IPropertyFactory<PropertyModel> propertyFactory) : base(createElement)
    {
        if (createElement.Element != null)
        {
            foreach (var property in createElement.Element.Properties)
            {
                Properties.Add(propertyFactory.GetProperty(property, createElement.Content, createElement.Culture, createElement.Segment, createElement.Fallback));
            }
        }
    }
}
