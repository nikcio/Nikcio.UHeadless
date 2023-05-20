namespace Nikcio.UHeadless.Base.Properties.Models;

/// <summary>
/// Represents a property fallback strategy
/// </summary>
public enum PropertyFallback
{
    /// <summary>
    /// Do not fallback
    /// </summary>
    None = 0,

    /// <summary>
    /// Fallback to default value
    /// </summary>
    DefaultValue = 1,

    /// <summary>
    /// Fallback to other languages
    /// </summary>
    Language = 2,

    /// <summary>
    /// Fallback to tree ancestors
    /// </summary>
    Ancestors = 3
}