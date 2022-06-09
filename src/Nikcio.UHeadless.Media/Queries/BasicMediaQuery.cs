using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Media.Models;

namespace Nikcio.UHeadless.Media.Queries {
    /// <summary>
    /// The default implementation of the Media queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicMediaQuery : MediaQuery<BasicMedia<BasicProperty, BasicContentType>, BasicProperty> {
    }
}
