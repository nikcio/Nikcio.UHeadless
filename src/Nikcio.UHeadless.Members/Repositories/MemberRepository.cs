using Nikcio.UHeadless.Members.Factories;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;

namespace Nikcio.UHeadless.Members.Repositories;

/// <inheritdoc/>
public class MemberRepository<TMember> : IMemberRepository<TMember>
    where TMember : IMember
{
    /// <summary>
    /// A factory for creating members
    /// </summary>
    protected readonly IMemberFactory<TMember> memberFactory;

    /// <summary>
    /// A member service
    /// </summary>
    protected readonly IMemberService memberService;

    /// <inheritdoc/>
    public MemberRepository(IUmbracoContextFactory umbracoContextFactory, IMemberFactory<TMember> memberFactory, IMemberService memberService)
    {
        umbracoContextFactory.EnsureUmbracoContext();
        this.memberFactory = memberFactory;
        this.memberService = memberService;
    }

    /// <inheritdoc/>
    public virtual TMember? GetMember(Func<IMemberService, Umbraco.Cms.Core.Models.IMember?> fetch)
    {
        var member = fetch(memberService);
        if (member is null)
        {
            return default;
        }
        return memberFactory.CreateMember(member);
    }

    /// <inheritdoc/>
    public virtual IEnumerable<TMember?> GetMemberList(Func<IMemberService, IEnumerable<Umbraco.Cms.Core.Models.IMember>?> fetch)
    {
        var members = fetch(memberService);
        if (members is null)
        {
            return Enumerable.Empty<TMember>();
        }
        return members.Select(memberFactory.CreateMember);
    }
}
