using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Basics.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Queries;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Core.GraphQL.Queries;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.Content.Basics.Queries;

/// <summary>
/// The default query implementation of the ContentByTag query
/// </summary>
[ExtendObjectType(typeof(Query))]
public class AuthContentByTagQuery : ContentByTagQuery<BasicContent, BasicProperty>
{
    /// <inheritdoc />
    [Authorize]
    public override IEnumerable<BasicContent?> ContentByTag(
        [Service] IContentRepository<BasicContent, BasicProperty> contentRepository,
        [Service] ITagService tagService,
        [GraphQLDescription("The tag to fetch.")] string tag,
        [GraphQLDescription("The tag group to fetch.")] string? tagGroup = null,
        [GraphQLDescription("The culture to fetch.")] string? culture = null,
        [GraphQLDescription("The property variation segment")] string? segment = null,
        [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return base.ContentByTag(contentRepository, tagService, tag, tagGroup, culture, segment, fallback);
    }
}
