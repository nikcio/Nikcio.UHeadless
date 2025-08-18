namespace Nikcio.UHeadless.Defaults.Properties;

/// <summary>
/// Represents focal point coordinates for an image
/// </summary>
[GraphQLDescription("Represents focal point coordinates for an image.")]
public class FocalPoint
{
    /// <summary>
    /// The left coordinate (0.0 to 1.0)
    /// </summary>
    [GraphQLDescription("The left coordinate (0.0 to 1.0)")]
    public decimal Left { get; set; }

    /// <summary>
    /// The top coordinate (0.0 to 1.0)
    /// </summary>
    [GraphQLDescription("The top coordinate (0.0 to 1.0)")]
    public decimal Top { get; set; }
}
