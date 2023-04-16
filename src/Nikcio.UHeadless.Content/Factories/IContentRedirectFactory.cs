using Nikcio.UHeadless.Content.Commands;
using Nikcio.UHeadless.Content.Models;

namespace Nikcio.UHeadless.Content.Factories;

/// <summary>
/// A factory for creating a content redirect
/// </summary>
/// <typeparam name="TContentRedirect"></typeparam>
public interface IContentRedirectFactory<out TContentRedirect>
    where TContentRedirect : IContentRedirect
{
    /// <summary>
    /// Creates a content redirect
    /// </summary>
    /// <param name="createContentRedirectCommand"></param>
    /// <returns></returns>
    TContentRedirect? CreateContentRedirect(CreateContentRedirect createContentRedirectCommand);
}