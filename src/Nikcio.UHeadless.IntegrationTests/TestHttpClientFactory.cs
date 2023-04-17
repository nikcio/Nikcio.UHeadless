namespace Nikcio.UHeadless.IntegrationTests;

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
