using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Nikcio.UHeadless.IntegrationTests;

public class Setup : IDisposable
{
    private bool _disposedValue;

    public Setup()
    {
        Factory = new IntegrationTestFactory();

        Scope = Factory.Services.GetRequiredService<IServiceScopeFactory>().CreateAsyncScope();

        var serviceCollection = new ServiceCollection();

        serviceCollection.AddTransient<IHttpClientFactory, TestHttpClientFactory>(_ => new TestHttpClientFactory(Factory));

        serviceCollection.AddUHeadlessClient();

        InternalServiceProvider = serviceCollection.BuildServiceProvider();
    }

    public IServiceProvider InternalServiceProvider { get; }

    internal IUHeadlessClient UHeadlessClient => InternalServiceProvider.GetRequiredService<IUHeadlessClient>();

    public IntegrationTestFactory Factory { get; }

    public AsyncServiceScope Scope { get; }

    public IServiceProvider ServiceProvider => Scope.ServiceProvider;

    public virtual HttpClient Client => Factory.CreateClient();

    public virtual ILogger Logger => GetRequiredService<ILogger<Setup>>();

    public virtual TType? GetService<TType>() => ServiceProvider.GetService<TType>();

    public virtual TType GetRequiredService<TType>() => ServiceProvider.GetService<TType>() ?? throw new InvalidOperationException("Unable to get service.");

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                Factory.CloseDatabase();
                Client.Dispose();
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
