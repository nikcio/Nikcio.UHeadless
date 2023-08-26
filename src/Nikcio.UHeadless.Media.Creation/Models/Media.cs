using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Media.Commands;

namespace Nikcio.UHeadless.Media.Models;

/// <summary>
/// A base for media
/// </summary>
public abstract class Media : Element, IMedia
{
    /// <inheritdoc/>
    protected Media(CreateMedia createMedia) : base(createMedia.CreateElement)
    {
    }
}
