using Nikcio.UHeadless.Base.Properties.Extensions;

namespace Nikcio.UHeadless.Creation.Extensions.Options;

/// <summary>
/// Options for Nikcio.UHeadless.Creation
/// </summary>
public class UHeadlessCreationOptions
{
    /// <summary>
    /// Options for the property services
    /// </summary>
    public virtual PropertyServicesOptions PropertyServicesOptions { get; set; } = new();
}
