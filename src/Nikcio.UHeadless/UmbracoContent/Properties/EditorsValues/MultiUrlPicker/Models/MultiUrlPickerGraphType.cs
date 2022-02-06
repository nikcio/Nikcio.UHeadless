using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MultiUrlPicker.Models
{
    [GraphQLDescription("Represents a multi url picker.")]
    public class MultiUrlPickerGraphType : PropertyValueBaseGraphType
    {
        [GraphQLDescription("Gets the links.")]
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
