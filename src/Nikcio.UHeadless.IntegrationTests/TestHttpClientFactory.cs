using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        var client = _factory.CreateDefaultClient(new Uri("http://localhost/graphql"), new Handler());
        return client;
    }

    private class Handler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var msg = await base.SendAsync(request, cancellationToken);
            if(msg.StatusCode == HttpStatusCode.InternalServerError)
            {
                var content = await msg.Content.ReadAsStringAsync();
                throw new Exception(content);
            }
            return msg;
        }
    }
}
