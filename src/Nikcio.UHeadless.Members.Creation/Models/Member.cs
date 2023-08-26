using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Members.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Members.Models;

/// <summary>
/// A base for member
/// </summary>
public abstract class Member : Element, IMember
{
    /// <inheritdoc/>
    protected Member(CreateMember createMember) : base(createMember.CreateElement)
    {
    }
}
