using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using Nikcio.UHeadless.IntegrationTests.TestProject;

namespace Nikcio.UHeadless.IntegrationTests;

public class IntegrationTestFactory : WebApplicationFactory<Program>
{
    private readonly string _dataSource = Guid.NewGuid().ToString();
    private string InMemoryConnectionString => $"Data Source={_dataSource};Mode=Memory;Cache=Shared;Foreign Keys=True;Pooling=True";
    private readonly SqliteConnection _databaseConnection;
    private bool _disposedValue;

    public IntegrationTestFactory()
    {
        // Shared in-memory databases get destroyed when the last connection is closed.
        // Keeping a connection open while this web application is used, ensures that the database does not get destroyed in the middle of a test.
        _databaseConnection = new SqliteConnection(InMemoryConnectionString);
        _databaseConnection.Open();
    }

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Development");
        Environment.SetEnvironmentVariable("TEST_STATUS", "Testing");
        builder.ConfigureAppConfiguration(conf =>
        {
            conf.AddInMemoryCollection(new KeyValuePair<string, string?>[]
            {
                new KeyValuePair<string, string?>("ConnectionStrings:umbracoDbDSN", InMemoryConnectionString),
                new KeyValuePair<string, string?>("ConnectionStrings:umbracoDbDSN_ProviderName", "Microsoft.Data.Sqlite")
            });
        });
    }

    protected override void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                CloseDatabase();
            }

            _disposedValue = true;
        }
    }

    public void CloseDatabase()
    {
        // When this application factory is disposed, close the connection to the in-memory database
        // This will destroy the in-memory database
        _databaseConnection.Close();
        _databaseConnection.Dispose();
    }
}
