using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Nikcio.UHeadless.IntegrationTests;

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
