using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Content.Router;

namespace Nikcio.UHeadless.Content.Extensions {
    /// <inheritdoc/>
    public static class RouterExtensions {
        /// <summary>
        /// Adds router services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddRouters(this IServiceCollection services) {
            services
                .AddScoped(typeof(IContentRouter<,,>), typeof(ContentRouter<,,>));

            return services;
        }
    }
}
