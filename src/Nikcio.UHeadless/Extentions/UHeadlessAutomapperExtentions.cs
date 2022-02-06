using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Nikcio.UHeadless.Extentions
{
    /// <summary>
    /// All UHeadless extentions that involve the Automapper package
    /// </summary>
    public static class UHeadlessAutomapperExtentions
    {
        /// <summary>
        /// Adds Automapper with a reference to the UHeadless assembly
        /// </summary>
        /// <param name="services">The service collection</param>
        /// <param name="automapperAssemblies">Any extra assemblies that should be added to Automapper</param>
        /// <returns></returns>
        public static IServiceCollection AddUHeadlessAutomapper(this IServiceCollection services, List<Assembly> automapperAssemblies)
        {
            if (automapperAssemblies == null)
            {
                automapperAssemblies = new List<Assembly>();
            }

            automapperAssemblies.Add(typeof(UHeadlessExtentions).Assembly);

            services
                .AddAutoMapper(automapperAssemblies);

            return services;
        }
    }
}
