using Nikcio.UHeadless.Members.Extensions;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;

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
    }
}
