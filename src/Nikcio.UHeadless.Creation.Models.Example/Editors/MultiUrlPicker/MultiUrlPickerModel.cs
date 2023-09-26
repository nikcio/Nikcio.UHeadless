using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MultiUrlPicker.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.MultiUrlPicker;

/// <summary>
/// Represents a multi url picker
/// </summary>
public class MultiUrlPickerModel : PropertyValue
{
    /// <summary>
    /// Gets the links
    /// </summary>
    public virtual List<MultiUrlPickerItemModel> Links { get; set; } = new();

    /// <inheritdoc/>
    public MultiUrlPickerModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
    {
        var value = createPropertyValue.Property.Value(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (value is IEnumerable<Link> links)
        {
            foreach (var link in links)
            {
                AddLinkPickerItem(dependencyReflectorFactory, link);
            }
        } else if (value is Link link)
        {
            AddLinkPickerItem(dependencyReflectorFactory, link);
        }
    }

    /// <summary>
    /// Adds a member item to the member picker
    /// </summary>
    /// <param name="dependencyReflectorFactory"></param>
    /// <param name="link"></param>
    protected void AddLinkPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, Link link)
    {
        var linkItem = dependencyReflectorFactory.GetReflectedType<MultiUrlPickerItemModel>(typeof(MultiUrlPickerItemModel), new object[] { new CreateMultiUrlPickerItem(link) });
        if (linkItem != null)
        {
            Links.Add(linkItem);
        }
    }
}
