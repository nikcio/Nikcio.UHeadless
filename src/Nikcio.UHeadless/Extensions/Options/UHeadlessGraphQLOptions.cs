using HotChocolate.Execution.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Extensions.Options;

/// <summary>
/// Options for UHeadless GraphQL
/// </summary>
public class UHeadlessGraphQLOptions
{
    /// <summary>
    /// Extensions for the GraphQL server
    /// </summary>
    /// <remarks>
    /// HotChocolate extensions can be added here
    /// </remarks>
    public virtual Func<IRequestExecutorBuilder, IRequestExecutorBuilder>? GraphQLExtensions { get; set; }

    /// <summary>
    /// A collection of all the type implementing <see cref="PropertyValue"/>
    /// </summary>
    /// <remarks>
    /// This will be filled automatically
    /// </remarks>
    public virtual List<Type> PropertyValueTypes { get; set; } = new();

    /// <summary>
    /// Whether or not to use subscriptions
    /// </summary>
    /// <remarks>
    /// Setting this to true will add the needed extensions to the GraphQL server
    /// </remarks>
    public virtual bool UseSubscriptions { get; set; }

    /// <summary>
    /// The subscription provider to use
    /// </summary>
    /// <remarks>
    /// Defaults to InMemory. Find more at https://chillicream.com/docs/hotchocolate/v13/defining-a-schema/subscriptions/#in-memory-provider
    /// </remarks>
    public virtual Action<IRequestExecutorBuilder>? SubscriptionProvider => UseSubscriptions ? builder => builder.AddInMemorySubscriptions() : null;
}
