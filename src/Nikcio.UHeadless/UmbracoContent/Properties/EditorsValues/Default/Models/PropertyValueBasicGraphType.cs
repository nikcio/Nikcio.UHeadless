using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;

namespace Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Models
{
    [GraphQLDescription("Represents a basic property value.")]
    public class PropertyValueBasicGraphType : PropertyValueBaseGraphType
    {
        [GraphQLType(typeof(AnyType))]
        [GraphQLDescription("Gets the value of the property.")]
        public object Value { get; set; }

        public PropertyValueBasicGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            Value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
        }
    }
}
