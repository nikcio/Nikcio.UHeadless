using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Mappers;

namespace Nikcio.Umbraco.Headless.Core.Extentions
{
    public static class HeadlessExtentions
    {
        public static IServiceCollection AddUmbracoHeadless(this IServiceCollection services)
        {
            services.AddMappers();

            return services;
        }
    }
}
