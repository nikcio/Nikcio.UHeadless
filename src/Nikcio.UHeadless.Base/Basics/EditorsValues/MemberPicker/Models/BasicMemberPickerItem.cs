using HotChocolate;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MemberPicker.Models;

/// <inheritdoc/>
[GraphQLDescription("Represents a member item.")]
public class BasicMemberPickerItem : BasicMemberPickerItem<BasicProperty>
{
    /// <inheritdoc/>
    public BasicMemberPickerItem(CreateMemberPickerItem createMember, IPropertyFactory<BasicProperty> propertyFactory) : base(createMember, propertyFactory)
    {
    }
}

/// <inheritdoc/>
[GraphQLDescription("Represents a member item.")]
public class BasicMemberPickerItem<TProperty> : MemberPickerItem
    where TProperty : IProperty
{
    /// <inheritdoc/>
    public BasicMemberPickerItem(CreateMemberPickerItem createMember, IPropertyFactory<TProperty> propertyFactory) : base(createMember)
    {
        if (createMember.Member == null)
        {
            return;
        }

        Id = createMember.Member.Id;
        Name = createMember.Member.Name;
        if (createMember.Member.Properties != null)
        {
            foreach (var property in createMember.Member.Properties)
            {
                Properties.Add(propertyFactory.GetProperty(property, createMember.CreatePropertyValue.Content, createMember.CreatePropertyValue.Culture, createMember.CreatePropertyValue.Segment, createMember.CreatePropertyValue.Fallback));
            }
        }
    }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the id of the member.")]
    public virtual int? Id { get; set; }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the name of a member.")]
    public virtual string? Name { get; set; }

    /// <inheritdoc/>
    [GraphQLDescription("Gets the properties of a member.")]
    public virtual List<TProperty?> Properties { get; set; } = new();
}
