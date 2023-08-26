
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Extensions;

/// <summary>
/// Property extensions
/// </summary>
public static class PropertyFallbackExtensions
{
    /// <summary>
    /// Transforms <see cref="PropertyFallback" /> to <see cref="Fallback" />
    /// </summary>
    /// <returns></returns>
    public static Fallback ToFallback(this IEnumerable<PropertyFallback> fallbackValues)
    {
        return Fallback.To(fallbackValues.Cast<int>().ToArray());
    }
}
