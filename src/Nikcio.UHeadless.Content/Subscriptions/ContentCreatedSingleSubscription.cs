using HotChocolate;
using HotChocolate.Types;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.EventMessages;
using Nikcio.UHeadless.Content.Models;
using Nikcio.UHeadless.Content.Repositories;
using Nikcio.UHeadless.Core.Constants;

namespace Nikcio.UHeadless.Content.Subscriptions;

/// <summary>
/// Implements the <see cref="ContentCreatedSingle" /> subscription>
/// </summary>
public class ContentCreatedSingleSubscription<TContent>
    where TContent : IContent
{
    /// <summary>
    /// Subscribes to the content created event
    /// </summary>
    /// <param name="contentRepository"></param>
    /// <param name="contentCreatedSingleEventMessage"></param>
    /// <param name="preview"></param>
    /// <param name="segment"></param>
    /// <param name="fallback"></param>
    /// <returns></returns>
    [Subscribe]
    [Topic(SubscriptionTopics.Content.ContentCreatedSingle)]
    public virtual TContent? ContentCreatedSingle([Service] IContentRepository<TContent> contentRepository,
                                            [EventMessage] ContentCreatedSingleEventMessage contentCreatedSingleEventMessage,
                                            [GraphQLDescription("Fetch preview values. Preview will show unpublished items.")] bool preview = false,
                                            [GraphQLDescription("The property variation segment")] string? segment = null,
                                            [GraphQLDescription("The property value fallback strategy")] IEnumerable<PropertyFallback>? fallback = null)
    {
        return contentRepository.GetContent(x => x?.GetById(preview, contentCreatedSingleEventMessage.ContentId), contentCreatedSingleEventMessage.EditedCulture, segment, fallback?.ToFallback());
    }
}
