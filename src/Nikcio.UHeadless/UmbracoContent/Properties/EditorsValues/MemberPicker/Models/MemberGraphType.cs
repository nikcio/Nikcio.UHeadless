using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models
{
    [GraphQLDescription("Represents a member item.")]
    public class MemberGraphType<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        public MemberGraphType(CreatePropertyValue createPropertyValue, IPublishedContent value, IPropertyFactory<TPropertyGraphType> propertyFactory)
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

        [GraphQLDescription("Gets the id of the member.")]
        public int Id { get; set; }

        [GraphQLDescription("Gets the name of a member.")]
        public string Name { get; set; }

        [GraphQLDescription("Gets the properties of a member.")]
        public List<TPropertyGraphType> Properties { get; set; } = new();
    }
}
