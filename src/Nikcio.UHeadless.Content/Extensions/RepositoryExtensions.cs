using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Content.Repositories;

namespace Nikcio.UHeadless.Content.Extensions {
    /// <summary>
    /// Repository extensions
    /// </summary>
    public static class RepositoryExtensions {
        /// <summary>
        /// Adds all the content repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddContentRepositories(this IServiceCollection services) {
            services
                .AddScoped(typeof(IContentRepository<,>), typeof(ContentRepository<,>))
                .AddScoped(typeof(IContentRedirectRepository<>), typeof(ContentRedirectRepository<>));

            return services;
        }
    }
}
