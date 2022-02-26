using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Queries
{
    [ExtendObjectType(typeof(Query))]
    public class PropertyQuery : PropertyQueryBase<PropertyGraphType>
    {
    }
}
