using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extensions
{
    /// <summary>
    /// Content extensions
    /// </summary>
    public static class ContentExtensions
    {
        /// <summary>
        /// Adds all the content services
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddContentServices(this IServiceCollection services)
        {
            services
                .AddContentRepositories();

            return services;
        }
    }
}
