using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoMedia.Media.Repositories;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Extensions
{
    /// <summary>
    /// Repository extensions
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Adds all the Media repositories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMediaRepositories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IMediaRepository<,>), typeof(MediaRepository<,>));

            return services;
        }
    }
}
