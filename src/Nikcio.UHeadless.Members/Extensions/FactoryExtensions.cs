using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Members.Factories;

namespace Nikcio.UHeadless.Members.Extensions {
    /// <inheritdoc/>
    public static class FactoryExtensions {
        /// <summary>
        /// Adds factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddFactories(this IServiceCollection services) {
            services
                .AddScoped(typeof(IMemberFactory<,>), typeof(MemberFactory<,>));

            return services;
        }
    }
}
