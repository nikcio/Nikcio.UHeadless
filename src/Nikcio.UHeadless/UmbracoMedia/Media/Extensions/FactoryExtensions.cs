using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoMedia.Media.Factories;

namespace Nikcio.UHeadless.UmbracoMedia.Media.Extensions {
    /// <inheritdoc/>
    public static class FactoryExtensions {
        /// <summary>
        /// Adds factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFactories(this IServiceCollection services) {
            services
                .AddScoped(typeof(IMediaFactory<,>), typeof(MediaFactory<,>));

            return services;
        }
    }
}
