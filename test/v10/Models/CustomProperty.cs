using HotChocolate.Types;
using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;

namespace v10.Models
{
    public class CustomProperty : BasicProperty
    {
        public CustomProperty(CreateProperty createProperty, IPropertyValueFactory propertyValueFactory) : base(createProperty, propertyValueFactory)
        {
        }

        [GraphQLType(typeof(AnyType))]
        public override PropertyValue? Value => base.Value;
    }
}
