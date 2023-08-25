using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.Members.Extensions;

/// <summary>
/// Member extensions
/// </summary>
public static class MemberCreationExtensions
{
    /// <summary>
    /// Adds all the Member services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddMemberServices(this IServiceCollection services)
    {
        services
            .AddMemberRepositories()
            .AddFactories();

        return services;
    }
}
