using HotChocolate.Types;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace v10.Models
{
    [ExtendObjectType(typeof(Query))]
    public class Custom2ContentQuery : ContentQuery<BasicContent<CustomProperty>, CustomProperty, BasicContentRedirect>
    {
    }
}
