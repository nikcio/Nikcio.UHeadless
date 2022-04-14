using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Queries
{
    /// <summary>
    /// The default implementation for the property queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicPropertyQuery : PropertyQuery<BasicProperty>
    {
    }
}
