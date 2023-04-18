using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Core.GraphQL.Queries;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default query implementation of the ContentByContentType query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthContentByContentTypeQuery : ContentByContentTypeQuery<BasicContent, BasicProperty>
{
    /// <inheritdoc />
    [Authorize]
    public override IEnumerable<BasicContent?> ContentByContentType(
        [Service] IContentRepository<BasicContent, BasicProperty> contentRepository,
        [GraphQLDescription("The contentType to fetch.")] string contentType,
        [GraphQLDescription("The culture.")] string? culture = null)
    {
        return base.ContentByContentType(contentRepository, contentType, culture);
    }
}
