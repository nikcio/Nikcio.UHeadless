﻿using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Members.Extensions;
using Nikcio.UHeadless.Members.NotificationHandlers;
using Nikcio.UHeadless.Members.TypeModules;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Members.Composers;

/// <summary>
/// Adds member services
/// </summary>
public class MemberComposer : IComposer
{
    /// <inheritdoc/>
    public void Compose(IUmbracoBuilder builder)
    {
        builder.Services.AddMemberServices();

        builder.AddNotificationAsyncHandler<MemberTypeChangedNotification, MemberTypeModuleMemberChangedHandler>();
        builder.Services.AddSingleton<MemberTypeModule>();
    }
}
