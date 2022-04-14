using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Extensions {
    /// <summary>
    /// Media extensions
    /// </summary>
    public static class MediaExtensions {
        /// <summary>
        /// Adds all the Media services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddMediaServices(this IServiceCollection services) {
            services
                .AddMediaRepositories()
                .AddFactories();

            return services;
        }
    }
}
