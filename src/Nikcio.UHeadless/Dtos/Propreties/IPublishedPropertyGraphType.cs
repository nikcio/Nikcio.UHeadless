using HotChocolate;
using HotChocolate.Types;
using Newtonsoft.Json.Linq;
using Nikcio.UHeadless.Models;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Dtos.Propreties
{
    public interface IPublishedPropertyGraphType
    {
        //
        // Summary:
        //     Gets the alias of the property.
        string Alias { get; }

        object Value { get; }
    }

}
