using HotChocolate;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models
{
    /// <summary>
    /// Represents a member picker
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a member picker.")]
    public class BasicMemberPicker<TProperty> : PropertyValue
        where TProperty : IProperty
    {
        /// <summary>
        /// Gets the members
        /// </summary>
        [GraphQLDescription("Gets the members.")]
        public virtual List<BasicMember<TProperty>> Members { get; set; } = new();

        /// <inheritdoc/>
        public BasicMemberPicker(CreatePropertyValue createPropertyValue, IPropertyFactory<TProperty> propertyFactory) : base(createPropertyValue)
        {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent content)
            {
                Members.Add(new(createPropertyValue, content, propertyFactory));
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
