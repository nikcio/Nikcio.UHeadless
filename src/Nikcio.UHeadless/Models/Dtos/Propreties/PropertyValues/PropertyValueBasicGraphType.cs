using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Commands.Properties;

namespace Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues
{
    public class PropertyValueBasicGraphType : PropertyValueBaseGraphType
    {
        [GraphQLType(typeof(AnyType))]
        public object Value { get; set; }

        public PropertyValueBasicGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            Value = createPropertyValue.Property.GetValue();
        }
    }
}
