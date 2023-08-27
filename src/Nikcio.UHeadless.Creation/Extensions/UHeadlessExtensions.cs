using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.ContentTypes.Extensions;
using Nikcio.UHeadless.Core.Reflection.Extensions;
using Nikcio.UHeadless.Creation.Extensions.Options;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Creation.Extensions;

/// <summary>
/// The default Nikcio.UHeadless.Creation extensions used for the default setup
/// </summary>
public static class UHeadlessExtensions
{
    /// <summary>
    /// Adds all services the Nikcio.UHeadless.Creation package needs
    /// </summary>
    /// <param name="builder">The Umbraco builder</param>
    /// <returns></returns>
    public static IUmbracoBuilder AddUHeadlessCreation(this IUmbracoBuilder builder)
    {
        var uHeadlessCreationOptions = new UHeadlessCreationOptions();
        return AddUHeadlessCreation(builder, uHeadlessCreationOptions);
    }

    /// <summary>
    /// Adds all services the Nikcio.UHeadless.Creation package needs
    /// </summary>
    /// <param name="builder">The Umbraco builder</param>
    /// <param name="uHeadlessCreationOptions"></param>
    /// <returns></returns>
    public static IUmbracoBuilder AddUHeadlessCreation(this IUmbracoBuilder builder, UHeadlessCreationOptions uHeadlessCreationOptions)
    {
        builder.Services
            .AddReflectionServices()
            .AddPropertyServices(uHeadlessCreationOptions.PropertyServicesOptions)
            .AddContentTypeServices();

        return builder;
    }
}
