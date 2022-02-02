using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;

namespace Nikcio.UHeadless.Models.Properties.Basic
{
    public class PropertyValueBasicGraphType : PropertyValueBaseGraphType
    {
        [GraphQLType(typeof(AnyType))]
        public object Value { get; set; }
        public string Type { get; set; }

        public PropertyValueBasicGraphType(CreatePropertyValue createPropertyValue) : base(createPropertyValue)
        {
            Value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            Type = Value?.GetType().AssemblyQualifiedName;
        }
    }
}
