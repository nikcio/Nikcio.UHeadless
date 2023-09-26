using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.MemberPicker;

/// <summary>
/// Represents a member picker
/// </summary>
public class MemberPickerModel : PropertyValue
{
    /// <summary>
    /// Gets the members
    /// </summary>
    public virtual List<MemberPickerItemModel> Members { get; set; } = new();

    /// <inheritdoc/>
    public MemberPickerModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
    {
        var objectValue = createPropertyValue.Property.Value(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (objectValue is IPublishedContent memberItem)
        {
            AddMemberPickerItem(dependencyReflectorFactory, createPropertyValue, memberItem);
        } else if (objectValue is IEnumerable<IPublishedContent> members)
        {
            foreach (var member in members)
            {
                AddMemberPickerItem(dependencyReflectorFactory, createPropertyValue, member);
            }
        }
    }

    /// <summary>
    /// Adds a member item to the member picker
    /// </summary>
    /// <param name="dependencyReflectorFactory"></param>
    /// <param name="createPropertyValue"></param>
    /// <param name="member"></param>
    protected void AddMemberPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, CreatePropertyValue createPropertyValue, IPublishedContent member)
    {
        var memberItem = dependencyReflectorFactory.GetReflectedType<MemberPickerItemModel>(typeof(MemberPickerItemModel), new object[] { new CreateMemberPickerItem(createPropertyValue, member) });
        if (memberItem != null)
        {
            Members.Add(memberItem);
        }
    }
}
