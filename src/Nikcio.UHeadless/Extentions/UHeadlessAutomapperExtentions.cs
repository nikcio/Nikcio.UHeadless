using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Reflection;

namespace Nikcio.UHeadless.Extentions
{
    public static class UHeadlessAutomapperExtentions
    {
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
