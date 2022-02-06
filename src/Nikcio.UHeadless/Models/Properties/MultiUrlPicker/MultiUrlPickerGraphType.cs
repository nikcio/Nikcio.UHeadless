using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.Models.Properties.MultiUrlPicker
{
    public class MultiUrlPickerGraphType : PropertyValueBaseGraphType
    {
        public List<LinkGraphType> Links { get; set; } = new();

        public MultiUrlPickerGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value is IEnumerable<Link> links)
            {
                foreach (var link in links)
                {
                    Links.Add(new LinkGraphType(link));
                }
            }
        }
    }
}
