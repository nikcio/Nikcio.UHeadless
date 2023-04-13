using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Nikcio.UHeadless.IntegrationTests.TestProject;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;
using StrawberryShake.Transport.Http;

namespace Nikcio.UHeadless.IntegrationTests;

[TestFixture]
[Parallelizable(ParallelScope.All)]
public abstract class IntegrationTestBase
{
}

public class TestHttpClientFactory : IHttpClientFactory
{
    private WebApplicationFactory<Program> _factory { get; }

    public TestHttpClientFactory(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    public HttpClient CreateClient(string name)
    {
        var client = _factory.CreateClient();
        client.BaseAddress = new Uri("https://localhost/graphql");
        return client;
    }
}

public class Setup
{
    public Setup()
    {
        Scope = Factory.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IHttpClientFactory, TestHttpClientFactory>(_ => new TestHttpClientFactory(Factory));

        serviceCollection.AddUHeadlessClient();

        InternalServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public IServiceProvider InternalServiceProvider { get; }

    public IUHeadlessClient UHeadlessClient => InternalServiceProvider.GetRequiredService<IUHeadlessClient>();

    public IntegrationTestFactory Factory { get; } = new IntegrationTestFactory();

    public AsyncServiceScope Scope { get; }

    public IServiceProvider ServiceProvider => Scope.ServiceProvider;

    public virtual HttpClient Client => Factory.CreateClient();

    public virtual ILogger Logger => GetRequiredService<ILogger<Setup>>();

    public virtual TType? GetService<TType>() => ServiceProvider.GetService<TType>();

    public virtual TType GetRequiredService<TType>() => ServiceProvider.GetService<TType>() ?? throw new InvalidOperationException("Unable to get service.");
}

public class ApiResponse
{
    public HttpResponseMessage ResponseMessage { get; }

    public string Response { get; }

    public ApiResponse(HttpResponseMessage responseMessage, string response)
    {
        ResponseMessage = responseMessage;
        Response = response;
    }

    public JObject JObjectResponse()
    {
        return JObject.Parse(Response);
    }

    public TType TypedResponse<TType>()
    {
        return JsonConvert.DeserializeObject<TType>(Response) ?? throw new InvalidOperationException("Unable to convert response to type.");
    }
}

public class IntegrationTestFactory : WebApplicationFactory<Program>
{
    private readonly string _dataSource = Guid.NewGuid().ToString();
    private string _inMemoryConnectionString => $"Data Source={_dataSource};Mode=Memory;Cache=Shared";
    private readonly SqliteConnection _databaseConnection;
    public IntegrationTestFactory()
    {
        // Shared in-memory databases get destroyed when the last connection is closed.
        // Keeping a connection open while this web application is used, ensures that the database does not get destroyed in the middle of a test.
        _databaseConnection = new SqliteConnection(_inMemoryConnectionString);
        _databaseConnection.Open();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        builder.ConfigureAppConfiguration(conf =>
        {
            conf.AddInMemoryCollection(new KeyValuePair<string, string?>[]
            {
                new KeyValuePair<string, string?>("ConnectionStrings:umbracoDbDSN", _inMemoryConnectionString),
                new KeyValuePair<string, string?>("ConnectionStrings:umbracoDbDSN_ProviderName", "Microsoft.Data.Sqlite")
            });
        });
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        // When this application factory is disposed, close the connection to the in-memory database
        // This will destroy the in-memory database
        _databaseConnection.Close();
        _databaseConnection.Dispose();
    }
}
