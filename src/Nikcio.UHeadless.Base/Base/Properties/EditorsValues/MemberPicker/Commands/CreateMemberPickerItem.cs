using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Core.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Commands;

/// <summary>
/// A command to create a member
/// </summary>
public class CreateMemberPickerItem : ICommand
{
    /// <inheritdoc/>
    public CreateMemberPickerItem(CreatePropertyValue createPropertyValue, IPublishedContent member)
    {
        CreatePropertyValue = createPropertyValue;
        Member = member;
    }

    /// <summary>
    /// A command for creating a property
    /// </summary>
    public CreatePropertyValue CreatePropertyValue { get; }

    /// <summary>
    /// The member
    /// </summary>
    public IPublishedContent Member { get; }
}
