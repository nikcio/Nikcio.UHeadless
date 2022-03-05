using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models
{
    /// <inheritdoc/>
    [GraphQLDescription("Represents a member item.")]
    public class MemberGraphType<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        [GraphQLDescription("Gets the id of the member.")]
        public virtual int? Id { get; set; }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the name of a member.")]
        public virtual string? Name { get; set; }

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of a member.")]
        public virtual List<TPropertyGraphType>? Properties { get; set; } = new();
    }
}
