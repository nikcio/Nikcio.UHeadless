using HotChocolate;
using HotChocolate.Types;
using Newtonsoft.Json.Linq;
using Nikcio.UHeadless.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.UHeadless.Dtos.Propreties
{
    public class PublishedPropertyGraphType : IPublishedPropertyGraphType
    {
        public string Alias { get; set; }

        [GraphQLType(typeof(AnyType))]
        public object Value { get; set; }
    }
}
