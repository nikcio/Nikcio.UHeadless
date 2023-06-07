using System;
using Examples.Docs.PropertyValues;
using HotChocolate.Execution.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nikcio.UHeadless.Content.Basics.Queries;
using Nikcio.UHeadless.Extensions;
using Nikcio.UHeadless.Extensions.Options;
using Nikcio.UHeadless.Media.Basics.Queries;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Extensions;

namespace Examples;

public class Startup
{
    private readonly IWebHostEnvironment _env;
    private readonly IConfiguration _config;

    /// <summary>
    /// Initializes a new instance of the <see cref="Startup" /> class.
    /// </summary>
    /// <param name="webHostEnvironment">The web hosting environment.</param>
    /// <param name="config">The configuration.</param>
    /// <remarks>
    /// Only a few services are possible to be injected here https://github.com/dotnet/aspnetcore/issues/9337.
    /// </remarks>
    public Startup(IWebHostEnvironment webHostEnvironment, IConfiguration config)
    {
        _env = webHostEnvironment ?? throw new ArgumentNullException(nameof(webHostEnvironment));
        _config = config ?? throw new ArgumentNullException(nameof(config));
    }

    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">The services.</param>
    /// <remarks>
    /// This method gets called by the runtime. Use this method to add services to the container.
    /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
    /// </remarks>
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddUmbraco(_env, _config)
            .AddBackOffice()
            .AddWebsite()
            .AddComposers()
            .AddUHeadless(new()
            {
                PropertyServicesOptions = new()
                {
                    PropertyMapOptions = new()
                    {
                        PropertyMappings = new() {
                            new((map) => map.AddEditorMapping<MyBlockListModel>(Constants.PropertyEditors.Aliases.BlockList)),
                            new((map) => map.AddAliasMapping<MyMediaPicker>("myContentType", "myPropertyAlias"))
                        }
                    },
                },
                TracingOptions = new()
                {
                    TimestampProvider = null,
                    TracingPreference = HotChocolate.Execution.Options.TracingPreference.Never,
                },
                UHeadlessGraphQLOptions = new()
                {
                    GraphQLExtensions = (IRequestExecutorBuilder builder) =>
                    {
                        builder.AddMaxExecutionDepthRule(10);
                        builder.AddTypeExtension<BasicContentAtRootQuery>();
                        builder.AddTypeExtension<BasicMediaAtRootQuery>();
                        builder.AddAuthorization();
                        return builder;
                    },
                },
            })
            .Build();
    }

    /// <summary>
    /// Configures the application.
    /// </summary>
    /// <param name="app">The application builder.</param>
    /// <param name="env">The web hosting environment.</param>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseUHeadlessGraphQLEndpoint(new UHeadlessEndpointOptions
        {
            CorsPolicy = null,
            GraphQLPath = "/graphql",
            GraphQLServerOptions = new()
            {
                Tool = {
                    Enable = true
                }
            }
        });

        app.UseUmbraco()
            .WithMiddleware(u =>
            {
                u.UseBackOffice();
                u.UseWebsite();
            })
            .WithEndpoints(u =>
            {
                u.UseInstallerEndpoints();
                u.UseBackOfficeEndpoints();
                u.UseWebsiteEndpoints();
            });
    }
}
