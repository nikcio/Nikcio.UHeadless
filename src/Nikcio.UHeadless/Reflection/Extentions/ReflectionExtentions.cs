using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.Reflection.Extentions
{
    public static class ReflectionExtentions
    {
        public static IServiceCollection AddReflectionServices(this IServiceCollection services)
        {
            services
                .AddReflectionFactories();

            return services;
        }
    }
}
