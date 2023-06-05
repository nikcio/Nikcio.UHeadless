using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Basics.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default query implementation of the ContentDescendantsByGuid query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthContentDescendantsByGuidQuery : ContentDescendantsByGuidQuery<BasicContent, BasicProperty>
{
    /// <inheritdoc />
    [Authorize]
    public override IEnumerable<BasicContent?> ContentDescendantsByGuid(
        [Service] IContentRepository<BasicContent, BasicProperty> contentRepository,
        [GraphQLDescription("The id to fetch.")] Guid id,
        [GraphQLDescription("The culture.")] string? culture = null,
        [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
        [GraphQLDescription("The property variation segment")] string? segment = null,
        [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return base.ContentDescendantsByGuid(contentRepository, id, culture, preview, segment, fallback);
    }
}
