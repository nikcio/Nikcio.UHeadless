using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Models.Properties.Members
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
