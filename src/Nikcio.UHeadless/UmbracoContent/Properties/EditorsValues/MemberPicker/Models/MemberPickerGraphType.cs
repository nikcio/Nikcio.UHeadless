using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models
{
    [GraphQLDescription("Represents a member picker.")]
    public class MemberPickerGraphType<TPropertyGraphType> : PropertyValueBaseGraphType
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        [GraphQLDescription("Gets the members.")]
        public virtual List<MemberGraphType<TPropertyGraphType>> Members { get; set; } = new();

        public MemberPickerGraphType(CreatePropertyValue createPropertyValue, IPropertyFactory<TPropertyGraphType> propertyFactory) : base(createPropertyValue)
        {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent content)
            {
                Members.Add(new(createPropertyValue, content, propertyFactory));
            }
            else if (objectValue is not null)
            {
                var members = (IEnumerable<IPublishedContent>)objectValue;
                if (members != null)
                {
                    foreach (var member in members)
                    {
                        Members.Add(new(createPropertyValue, member, propertyFactory));
                    }
                }
            }

        }
    }
}
