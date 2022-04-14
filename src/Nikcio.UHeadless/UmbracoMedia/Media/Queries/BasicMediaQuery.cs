using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Nikcio.UHeadless.UmbracoMedia.Media.Models;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Queries
{
    /// <summary>
    /// The default implementation of the Media queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class BasicMediaQuery : MediaQuery<BasicMedia<BasicProperty, BasicContentType>, BasicProperty>
    {
    }
}
