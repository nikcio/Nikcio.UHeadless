using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models
{
    public class MemberGraphType
    {
        public MemberGraphType(CreatePropertyValue createPropertyValue, IPublishedContent value, IPropertyFactory propertyFactory)
        {
            if (value == null)
            {
                return;
            }

            Id = value.Id;
            Name = value.Name;
            if (value.Properties != null)
            {
                foreach (var property in value.Properties)
                {
                    Properties.Add(propertyFactory.GetPropertyGraphType(property, createPropertyValue.Content, createPropertyValue.Culture));
                }
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public List<PropertyGraphType> Properties { get; set; } = new();
    }
}
