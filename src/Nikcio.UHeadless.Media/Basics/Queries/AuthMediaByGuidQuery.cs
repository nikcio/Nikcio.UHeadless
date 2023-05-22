using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Queries;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Basics.Queries;

/// <summary>
/// The default query implementation of the MediaByGuid query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMediaByGuidQuery : MediaByGuidQuery<BasicMedia, BasicProperty>
{
    /// <inheritdoc />
    [Authorize]
    public override BasicMedia? MediaByGuid([Service] IMediaRepository<BasicMedia, BasicProperty> MediaRepository, [GraphQLDescription("The id to fetch.")] Guid id, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return base.MediaByGuid(MediaRepository, id, preview);
    }
}
