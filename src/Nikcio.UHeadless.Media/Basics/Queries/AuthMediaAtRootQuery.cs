using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Nikcio.UHeadless.Media.Basics.Models;
using Nikcio.UHeadless.Media.Queries;
using Nikcio.UHeadless.Media.Repositories;

namespace Nikcio.UHeadless.Media.Basics.Queries;

/// <summary>
/// The default query implementation of the MediaAtRoot query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthMediaAtRootQuery : MediaAtRootQuery<BasicMedia, BasicProperty>
{
    /// <inheritdoc />
    [Authorize]
    public override IEnumerable<BasicMedia?> MediaAtRoot([Service] IMediaRepository<BasicMedia, BasicProperty> MediaRepository, [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false)
    {
        return base.MediaAtRoot(MediaRepository, preview);
    }
}
