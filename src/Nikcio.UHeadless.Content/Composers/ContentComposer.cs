using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Content.Extensions;
using Nikcio.UHeadless.Content.NotificationHandlers;
using Nikcio.UHeadless.Content.TypeModules;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Content.Composers;

/// <summary>
/// Adds content services
/// </summary>
public class ContentComposer : IComposer
{
    /// <inheritdoc/>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddContentServices();

        builder.AddNotificationAsyncHandler<ContentTypeChangedNotification, ContentTypeModuleContentTypeChangedHandler>();
        builder.Services.AddSingleton<ContentTypeModule>();
    }
}
