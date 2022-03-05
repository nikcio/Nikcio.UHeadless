using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Nikcio.UHeadless.Extensions
{
    /// <summary>
    /// All UHeadless extensions that involve the Automapper package
    /// </summary>
    public static class UHeadlessAutomapperExtensions
    {
        /// <summary>
        /// Adds Automapper with a reference to the UHeadless assembly
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="automapperAssemblies">Any extra assemblies that should be added to Automapper</param>
        /// <returns></returns>
        public static IServiceCollection AddUHeadlessAutomapper(this IServiceCollection services, List<Assembly>? automapperAssemblies)
        {
            if (automapperAssemblies == null)
            {
                automapperAssemblies = new List<Assembly>();
            }

            automapperAssemblies.Add(typeof(UHeadlessExtensions).Assembly);

            services
                .AddAutoMapper(automapperAssemblies);

            return services;
        }
    }
}
