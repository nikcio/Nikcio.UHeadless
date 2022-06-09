using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Properties.Factories;

namespace Nikcio.UHeadless.Properties.Extensions {
    /// <summary>
    /// Factory extensions
    /// </summary>
    public static class FactoryExtensions {
        /// <summary>
        /// Adds all the property factories
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyFactories(this IServiceCollection services) {
            services
                .AddScoped(typeof(IPropertyFactory<>), typeof(PropertyFactory<>))
                .AddScoped<IPropertyValueFactory, PropertyValueFactory>();

            return services;
        }
    }
}
