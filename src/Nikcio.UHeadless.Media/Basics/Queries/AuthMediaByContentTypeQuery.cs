using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Queries;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Basics.Queries;

/// <summary>
/// The default query implementation of the MediaByContentType query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMediaByContentTypeQuery : MediaByContentTypeQuery<BasicMedia>
{
    /// <inheritdoc />
    [Authorize]
    public override IEnumerable<BasicMedia?> MediaByContentType([Service] IMediaRepository<BasicMedia> mediaRepository, [GraphQLDescription("The contentType to fetch.")] string contentType)
    {
        return base.MediaByContentType(mediaRepository, contentType);
    }
}
