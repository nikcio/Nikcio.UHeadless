using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Queries
{
    /// <summary>
    /// The default implementation for the property queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicPropertyQuery : PropertyQuery<BasicProperty>
    {
    }
}
