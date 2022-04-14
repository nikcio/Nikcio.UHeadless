using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models {
    /// <inheritdoc/>
    [GraphQLDescription("Represents a member item.")]
    public class BasicMember<TProperty>
        where TProperty : IProperty {
        /// <inheritdoc/>
        public BasicMember(CreatePropertyValue createPropertyValue, IPublishedContent value, IPropertyFactory<TProperty> propertyFactory) {
            if (value == null) {
                return;
            }

            Id = value.Id;
            Name = value.Name;
            if (value.Properties != null) {
                foreach (var property in value.Properties) {
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
        public virtual List<TProperty?> Properties { get; set; } = new();
    }
}
