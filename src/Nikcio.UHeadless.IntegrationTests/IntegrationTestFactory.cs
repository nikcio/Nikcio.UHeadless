namespace Nikcio.UHeadless.IntegrationTests;

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
