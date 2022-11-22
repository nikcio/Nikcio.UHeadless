using HotChocolate.AspNetCore;

namespace Nikcio.UHeadless.Extensions.Options;

/// <summary>
/// Options for the UHeadless Endpoint configuration
/// </summary>
public class UHeadlessEndpointOptions
{
    /// <summary>
    /// Alternate cors policy to use. If not defined it will call the UseCors()
    /// </summary>
    public virtual string? CorsPolicy { get; set; }

    /// <summary>
    /// The path where the graphql endpoint will be placed
    /// </summary>
    public virtual string GraphQLPath { get; set; } = "/graphql";

    /// <summary>
    /// If true adds <code>applicationBuilder.UseAuthentication().UseAuthorization();</code>
    /// </summary>
    public virtual bool UseSecurity { get; set; }

    /// <summary>
    /// Options for the GraphQL endpoint
    /// </summary>
    public virtual GraphQLServerOptions GraphQLServerOptions { get; set; } = new();
}
