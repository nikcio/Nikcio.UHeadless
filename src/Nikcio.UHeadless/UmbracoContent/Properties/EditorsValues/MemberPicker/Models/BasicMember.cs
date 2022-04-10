using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Fallback.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a member item.")]
    public class BasicMember<TProperty>
        where TProperty : IProperty
    {
        /// <inheritdoc/>
        public BasicMember(CreatePropertyValue createPropertyValue, IPublishedContent value, IPropertyFactory<TProperty> propertyFactory)
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
                    Properties.Add(propertyFactory.GetProperty(property, createPropertyValue.Content, createPropertyValue.Culture));
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
        public virtual List<TProperty>? Properties { get; set; } = new();
    }
}
