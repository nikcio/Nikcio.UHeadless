using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.UHeadless.Models
{
    public class PropertyValueBaseGraphType
    {
        [GraphQLType(typeof(AnyType))]
        public object RawValue { get; set; }
    }
}
