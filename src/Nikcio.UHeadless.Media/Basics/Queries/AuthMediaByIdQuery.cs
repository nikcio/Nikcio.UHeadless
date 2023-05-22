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
/// The default query implementation of the MediaById query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMediaByIdQuery : MediaByIdQuery<BasicMedia, BasicProperty>
{
    /// <inheritdoc />
    [Authorize]
    public override BasicMedia? MediaById([Service] IMediaRepository<BasicMedia, BasicProperty> MediaRepository, [GraphQLDescription("The id to fetch.")] int id, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return base.MediaById(MediaRepository, id, preview);
    }
}
