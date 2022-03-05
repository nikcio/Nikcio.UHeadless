using HotChocolate.Types;
using Nikcio.UHeadless.Queries;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using Nikcio.UHeadless.UmbracoMedia.Media.Models;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Queries
{
    /// <summary>
    /// The default implementation of the Media queries
    /// </summary>
    [ExtendObjectType(typeof(Query))]
    public class MediaQuery : MediaQueryBase<MediaGraphType<PropertyGraphType>, PropertyGraphType>
    {
    }
}
