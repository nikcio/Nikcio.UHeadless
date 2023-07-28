using HotChocolate;
using HotChocolate.Authorization;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.EventMessages;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Content.Subscriptions;

namespace Nikcio.UHeadless.Content.Basics.Subscriptions;

/// <summary>
/// The default subscription implementation of the ContentCreatedSingle subscription
/// </summary>
public class AuthContentCreatedSingleSubscription : ContentCreatedSingleSubscription<BasicContent>
{
    /// <inheritdoc/>
    [Authorize]
    public override BasicContent? ContentCreatedSingle([Service] IContentRepository<BasicContent> contentRepository, 
                                                        [EventMessage] ContentCreatedSingleEventMessage ContentAddedSingleEventMessage, 
                                                        [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false, 
                                                        [GraphQLDescription("The property variation segment")] string? segment = null, 
                                                        [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return base.ContentCreatedSingle(contentRepository, ContentAddedSingleEventMessage, preview, segment, fallback);
    }
}
