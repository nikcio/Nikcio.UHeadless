using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models
{
    public class MemberPickerGraphType : PropertyValueBaseGraphType
    {
        public List<MemberGraphType> Members { get; set; } = new();

        public MemberPickerGraphType(CreatePropertyValue createPropertyValue, IPropertyFactory propertyFactory) : base(createPropertyValue)
        {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent)
            {
                Members.Add(new(createPropertyValue, (IPublishedContent)objectValue, propertyFactory));
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
