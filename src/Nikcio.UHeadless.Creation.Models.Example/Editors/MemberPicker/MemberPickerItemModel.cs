using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Creation.Models.Example.Properties;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.MemberPicker;

/// <inheritdoc/>
public class MemberPickerItemModel : MemberPickerItem
{
    /// <inheritdoc/>
    public MemberPickerItemModel(CreateMemberPickerItem createMember, IPropertyFactory<PropertyModel> propertyFactory, ILogger<MemberPickerItemModel> logger) : base(createMember)
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
                PropertyModel? propertyModel = propertyFactory.GetProperty(property, createMember.CreatePropertyValue.Content, createMember.CreatePropertyValue.Culture, createMember.CreatePropertyValue.Segment, createMember.CreatePropertyValue.Fallback);

                if (propertyModel == null)
                {
                    logger.LogWarning("Property model is null on member picker item. Property: {propertyAlias}", property.Alias);
                    continue;
                }

                Properties.Add(propertyModel.Alias, propertyModel);
            }
        }
    }

    /// <inheritdoc/>
    public virtual int? Id { get; set; }

    /// <inheritdoc/>
    public virtual string? Name { get; set; }

    /// <inheritdoc/>
    public virtual Dictionary<string, PropertyModel> Properties { get; set; } = new();
}
