using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;

namespace Nikcio.UHeadless.UmbracoContent.Content.Queries
{
    /// <summary>
    /// The default implementation of the content queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicContentQuery : ContentQuery<BasicContent<BasicProperty, BasicContentType>, BasicProperty>
    {
    }
}
