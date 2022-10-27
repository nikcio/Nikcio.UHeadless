using Microsoft.Extensions.DependencyInjection;
using Umbraco.Forms.Web.Controllers.Api;

namespace Nikcio.UHeadless.Umbraco.Forms.Extensions;

/// <summary>
/// Extensions for the Umbraco.Forms extension for Nikcio.UHeadless
/// </summary>
public static class UmbracoFormsExtensions
{
    /// <summary>
    /// Adds Umbraco forms services
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddUmbracoFormsServices(this IServiceCollection services)
    {

        return services;
    }
}
