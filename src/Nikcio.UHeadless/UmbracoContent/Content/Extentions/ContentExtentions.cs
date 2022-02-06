using Microsoft.Extensions.DependencyInjection;

namespace Nikcio.UHeadless.UmbracoContent.Content.Extentions
{
    /// <summary>
    /// Content extentions
    /// </summary>
    public static class ContentExtentions
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
