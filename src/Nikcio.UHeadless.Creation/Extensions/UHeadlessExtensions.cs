using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.ContentTypes.Extensions;
using Nikcio.UHeadless.Core.Reflection.Extensions;
using Nikcio.UHeadless.Creation.Extensions.Options;
using Umbraco.Cms.Core.DependencyInjection;

namespace Nikcio.UHeadless.Creation.Extensions;

/// <summary>
/// The default UHeadless extensions used for the default setup
/// </summary>
public static class UHeadlessExtensions
{
    /// <summary>
    /// Adds all services the UHeadless package needs
    /// </summary>
    /// <param name="builder">The Umbraco builder</param>
    /// <returns></returns>
    public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder)
    {
        var uHeadlessCreationOptions = new UHeadlessCreationOptions();
        return AddUHeadless(builder, uHeadlessCreationOptions);
    }

    /// <summary>
    /// Adds all services the UHeadless package needs
    /// </summary>
    /// <param name="builder">The Umbraco builder</param>
    /// <param name="uHeadlessCreationOptions"></param>
    /// <returns></returns>
    public static IUmbracoBuilder AddUHeadless(this IUmbracoBuilder builder, UHeadlessCreationOptions uHeadlessCreationOptions)
    {
        builder.Services
            .AddReflectionServices()
            .AddPropertyServices(uHeadlessCreationOptions.PropertyServicesOptions)
            .AddContentTypeServices();

        return builder;
    }
}
