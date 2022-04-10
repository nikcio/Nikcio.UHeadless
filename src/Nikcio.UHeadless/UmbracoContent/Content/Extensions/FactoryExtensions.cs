using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Content.Factories;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extensions
{
    public static class FactoryExtensions
    {
        public static IServiceCollection AddFactories(this IServiceCollection services)
        {
            services
                .AddScoped(typeof(IContentFactory<,>), typeof(ContentFactory<,>));

            return services;
        }
    }
}
