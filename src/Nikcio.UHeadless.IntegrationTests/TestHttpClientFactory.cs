using Microsoft.AspNetCore.Mvc.Testing;
using Nikcio.UHeadless.IntegrationTests.TestProject;

namespace Nikcio.UHeadless.IntegrationTests;

public class TestHttpClientFactory : IHttpClientFactory
{
    private readonly WebApplicationFactory<Program> _factory;

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
