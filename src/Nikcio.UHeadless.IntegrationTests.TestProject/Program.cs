using HotChocolate.Execution.Configuration;
using Microsoft.Data.Sqlite;
using Nikcio.UHeadless.Content.Basics.Queries;
using Nikcio.UHeadless.Content.Extensions;
using Nikcio.UHeadless.Extensions;
using Nikcio.UHeadless.IntegrationTests.TestProject;
using Nikcio.UHeadless.Media.Basics.Queries;
using Nikcio.UHeadless.Media.Extensions;
using Nikcio.UHeadless.Members.Basics.Queries;
using Nikcio.UHeadless.Members.Extensions;
using Umbraco.Cms.Core;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

var databaseMaintainer = new DatabaseMaintainer(builder.Configuration);

builder.Services.AddSingleton(databaseMaintainer);

builder.Services.AddErrorFilter<GraphQLErrorFilter>();

builder.Services.ConfigureOptions<ConfigureExamineIndexes>();

builder.CreateUmbracoBuilder()
    .AddBackOffice()
    .AddWebsite()
    .AddDeliveryApi()
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
                builder.AddAuthorization();

                builder.UseContentQueries();
                builder.AddTypeExtension<BasicContentAllQuery>();
                builder.AddTypeExtension<BasicContentAtRootQuery>();
                builder.AddTypeExtension<BasicContentByAbsoluteRouteQuery>();
                builder.AddTypeExtension<BasicContentByContentTypeQuery>();
                builder.AddTypeExtension<BasicContentByGuidQuery>();
                builder.AddTypeExtension<BasicContentByIdQuery>();
                builder.AddTypeExtension<BasicContentByTagQuery>();
                builder.AddTypeExtension<BasicContentDescendantsByAbsoluteRouteQuery>();
                builder.AddTypeExtension<BasicContentDescendantsByContentTypeQuery>();
                builder.AddTypeExtension<BasicContentDescendantsByGuidQuery>();
                builder.AddTypeExtension<BasicContentDescendantsByIdQuery>();

                builder.UseMediaQueries();
                builder.AddTypeExtension<BasicMediaAtRootQuery>();
                builder.AddTypeExtension<BasicMediaByContentTypeQuery>();
                builder.AddTypeExtension<BasicMediaByGuidQuery>();
                builder.AddTypeExtension<BasicMediaByIdQuery>();

                builder.UseMemberQueries();
                builder.AddTypeExtension<BasicMembersAllQuery>();
                builder.AddTypeExtension<BasicFindMembersByDisplayNameQuery>();
                builder.AddTypeExtension<BasicFindMembersByEmailQuery>();
                builder.AddTypeExtension<BasicFindMembersByRoleQuery>();
                builder.AddTypeExtension<BasicFindMembersByUsernameQuery>();
                builder.AddTypeExtension<BasicMemberByEmailQuery>();
                builder.AddTypeExtension<BasicMemberByIdQuery>();
                builder.AddTypeExtension<BasicMemberByKeyQuery>();
                builder.AddTypeExtension<BasicMemberByUsernameQuery>();
                builder.AddTypeExtension<BasicMembersByIdQuery>();
                return builder;
            },
        },
    })
    .Build();

WebApplication app = builder.Build();

await app.BootUmbracoAsync();

app.UseAuthentication();
app.UseAuthorization();


app.MapUHeadlessGraphQLEndpoint(new()
{
    CorsPolicy = null,
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

await app.RunAsync();

public partial class Program { }

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
        _databaseConnection.Dispose();
        GC.SuppressFinalize(this);
    }
}