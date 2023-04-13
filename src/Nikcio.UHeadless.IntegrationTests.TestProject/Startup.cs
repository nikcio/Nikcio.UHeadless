using Examine;
using HotChocolate.Execution.Configuration;
using Lucene.Net.Store;
using Microsoft.Data.Sqlite;
using Nikcio.UHeadless.Basics.Properties.Queries;
using Nikcio.UHeadless.Content.Basics.Queries;
using Nikcio.UHeadless.Extensions;
using Nikcio.UHeadless.Media.Basics.Queries;
using Nikcio.UHeadless.Members.Basics.Queries;
using Umbraco.Cms.Core;
using Umbraco.Cms.Infrastructure.Examine;
using Umbraco.Cms.Infrastructure.Examine.DependencyInjection;

namespace Nikcio.UHeadless.IntegrationTests.TestProject;

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
        var databaseMaintainer = new DatabaseMaintainer(_config);
        services.AddSingleton(databaseMaintainer);

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
                        PropertyMappings = new()
                        {
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
                        builder.AddTypeExtension<BasicContentQuery>();
                        builder.AddTypeExtension<BasicPropertyQuery>();
                        builder.AddTypeExtension<BasicMediaQuery>();
                        builder.AddTypeExtension<BasicMemberQuery>();
                        return builder;
                    },
                    UseSecurity = false,
                },
            })
            .Build();

        services.ConfigureOptions<ConfigureExamineIndexes>();
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

        app.UseUHeadlessGraphQLEndpoint(new()
        {
            CorsPolicy = null,
            UseSecurity = false,
            GraphQLPath = "/graphql",
            GraphQLServerOptions = new()
            {
                Tool =
                {
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


public class DatabaseMaintainer : IDisposable
{

    private readonly SqliteConnection _databaseConnection;

    public DatabaseMaintainer(IConfiguration config)
    {
        _databaseConnection = new SqliteConnection(config.GetConnectionString(Constants.System.UmbracoConnectionName));
        _databaseConnection.Open();
    }

    public void Dispose()
    {
        _databaseConnection.Close();
    }
}