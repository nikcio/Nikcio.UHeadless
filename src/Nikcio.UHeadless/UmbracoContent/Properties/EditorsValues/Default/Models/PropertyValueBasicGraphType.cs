using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Models
{
    /// <summary>
    /// Represents a basic property value
    /// </summary>
    [GraphQLDescription("Represents a basic property value.")]
    public class PropertyValueBasicGraphType : PropertyValueBaseGraphType
    {
        /// <summary>
        /// Gets the value of the property
        /// </summary>
        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of the property.")]
        public virtual object Value { get; set; }

        /// <inheritdoc/>
        public PropertyValueBasicGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            Value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        }
    }
}
