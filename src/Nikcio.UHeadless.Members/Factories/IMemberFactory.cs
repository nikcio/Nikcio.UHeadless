using Nikcio.UHeadless.Members.Models;

namespace Nikcio.UHeadless.Members.Factories;

/// <summary>
/// A factory for creating members
/// </summary>
/// <typeparam name="TMember"></typeparam>
public interface IMemberFactory<out TMember>
    where TMember : IMember
{
    /// <summary>
    /// Creates a member
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    TMember? CreateMember(Umbraco.Cms.Core.Models.IMember member);
}