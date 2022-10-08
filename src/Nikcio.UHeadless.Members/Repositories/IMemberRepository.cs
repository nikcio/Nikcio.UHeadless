using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Members.Models;
using Umbraco.Cms.Core.Services;

namespace Nikcio.UHeadless.Members.Repositories;

/// <summary>
/// A repository to get Member from Umbraco
/// </summary>
public interface IMemberRepository<TMember, TProperty>
    where TMember : IMember<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// Gets the Member based on a fetch method
    /// </summary>
    /// <param name="fetch">The fetch method</param>
    /// <param name="culture"></param>
    /// <returns></returns>
    TMember? GetMember(Func<IMemberService, Umbraco.Cms.Core.Models.IMember?> fetch, string? culture);

    /// <summary>
    /// Gets a Member lsit based on a fetch method
    /// </summary>
    /// <param name="fetch">The fetch method</param>
    /// <param name="culture"></param>
    /// <returns></returns>
    IEnumerable<TMember?> GetMemberList(Func<IMemberService, IEnumerable<Umbraco.Cms.Core.Models.IMember>?> fetch, string? culture);
}