using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Members.Repositories;

namespace Nikcio.UHeadless.Members.Extensions {
    /// <summary>
    /// Repository extensions
    /// </summary>
    public static class RepositoryExtensions {
        /// <summary>
        /// Adds all the Member repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMemberRepositories(this IServiceCollection services) {
            services
                .AddScoped(typeof(IMemberRepository<,>), typeof(MemberRepository<,>));

            return services;
        }
    }
}
