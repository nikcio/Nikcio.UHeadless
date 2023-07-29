using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.EventMessages;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Content.Subscriptions;
using Nikcio.UHeadless.Core.GraphQL.Subscriptions;

namespace Nikcio.UHeadless.Content.Basics.Subscriptions;

/// <summary>
/// Default subscription implementation for the ContentCreated subscription
/// </summary>
[ExtendObjectType(typeof(Subscription))]
public class AuthContentCreatedSubscription : ContentCreatedSubscription<BasicContent>
{
    /// <inheritdoc/>
    [Authorize]
    public override IEnumerable<BasicContent?> ContentCreated([Service] IContentRepository<BasicContent> contentRepository, 
                                                                [EventMessage] ContentCreatedEventMessage ContentCreatedEventMessage, 
                                                                [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
                                                                [GraphQLDescription("The property variation segment")] string? segment = null, 
                                                                [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return base.ContentCreated(contentRepository, ContentCreatedEventMessage, preview, segment, fallback);
    }
}
