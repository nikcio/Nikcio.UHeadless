using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Content.Factories;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extensions {
    /// <inheritdoc/>
    public static class FactoryExtensions {
        /// <summary>
        /// Adds factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFactories(this IServiceCollection services) {
            services
                .AddScoped(typeof(IContentFactory<,>), typeof(ContentFactory<,>));

            return services;
        }
    }
}
