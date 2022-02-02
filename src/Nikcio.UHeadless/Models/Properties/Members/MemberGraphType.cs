using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Models.Properties.Members
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
        public List<PublishedPropertyGraphType> Properties { get; set; } = new();
    }
}
