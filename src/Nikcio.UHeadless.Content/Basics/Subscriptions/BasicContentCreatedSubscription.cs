using HotChocolate.Types;
using Nikcio.UHeadless.Content.Basics.Models;
using Nikcio.UHeadless.Content.Subscriptions;
using Nikcio.UHeadless.Core.GraphQL.Subscriptions;

namespace Nikcio.UHeadless.Content.Basics.Subscriptions;

/// <summary>
/// Default subscription implementation for the ContentCreated subscription
/// </summary>
[ExtendObjectType(typeof(Subscription))]
public class BasicContentCreatedSubscription : ContentCreatedSubscription<BasicContent>
{
}
