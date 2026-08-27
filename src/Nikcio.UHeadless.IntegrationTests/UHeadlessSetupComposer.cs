using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nikcio.UHeadless.IntegrationTests.TestProject;
using Umbraco.Cms.Core.Composing;

namespace Nikcio.UHeadless.IntegrationTests;

/// <summary>
/// Sets up UHeadless based on the active <see cref="ApplicationFactoryBase{TProgram}"/>
/// </summary>
public class UHeadlessSetupComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        string? headlessSetupTypeName = builder.Config[nameof(ApplicationFactoryBase<TestProject.Program>.UHeadlessSetup)];

        ArgumentException.ThrowIfNullOrWhiteSpace(headlessSetupTypeName);

        var headlessSetup = (UHeadlessSetup?) Activator.CreateInstance(Type.GetType(headlessSetupTypeName) ?? throw new InvalidOperationException("Couldn't create the UHeadless test setup"));

        ArgumentNullException.ThrowIfNull(headlessSetup);

        var setup = headlessSetup.GetSetup();
        builder.AddUHeadless(options =>
        {
            setup(options);
            options.RequestExecutorBuilder
                .AddApplicationService<ILogger<GraphQLErrorFilter>>()
                .AddErrorFilter<GraphQLErrorFilter>();
        });
    }
}
