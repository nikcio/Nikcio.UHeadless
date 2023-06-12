using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default query implementation of the ContentAll query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthContentAllQuery : ContentAllQuery<BasicContent>
{
    /// <inheritdoc />
    [Authorize]
    public override IEnumerable<BasicContent?> ContentAll(
        [Service] IContentRepository<BasicContent> contentRepository,
        [GraphQLDescription("The culture.")] string? culture = null,
        [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
        [GraphQLDescription("The property variation segment")] string? segment = null,
        [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return base.ContentAll(contentRepository, culture, preview, segment, fallback);
    }
}
