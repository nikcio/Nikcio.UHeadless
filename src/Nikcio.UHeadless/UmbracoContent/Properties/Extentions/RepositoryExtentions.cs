using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.UmbracoContent.Properties.Repositories;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Extentions
{
    public static class RepositoryExtentions
    {
        public static IServiceCollection AddPropertyRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IPropertyRespository, PropertyRespository>();

            return services;
        }
    }
}
