using Nikcio.UHeadless.Members.TypeModules;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Notifications;

namespace Nikcio.UHeadless.Members.NotificationHandlers;

/// <summary>
/// Triggers GraphQL schema rebuild when member types changes
/// </summary>
public class MemberTypeModuleMemberChangedHandler : INotificationAsyncHandler<MemberTypeChangedNotification>
{
    private readonly MemberTypeModule _memberTypeModule;

    /// <inheritdoc/>
    public MemberTypeModuleMemberChangedHandler(MemberTypeModule memberTypeModule)
    {
        _memberTypeModule = memberTypeModule;
    }

    /// <inheritdoc/>
    public Task HandleAsync(MemberTypeChangedNotification notification, CancellationToken cancellationToken)
    {
        _memberTypeModule.OnTypesChanged(EventArgs.Empty);

        return Task.CompletedTask;
    }
}
