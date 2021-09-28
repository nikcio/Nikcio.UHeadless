using Microsoft.Extensions.DependencyInjection;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData;

namespace Nikcio.Umbraco.Headless.Core.Mappers
{
    public static class MapperExtentions
    {
        public static IServiceCollection AddMappers(this IServiceCollection services)
        {
            services.AddSingleton<IPropertyMapper, PropertyMapper>();
            services.AddSingleton<IPageMapper, PageMapper>();
            services.AddSingleton<ISiteMapper, SiteMapper>();

            return services;
        }
    }
}
