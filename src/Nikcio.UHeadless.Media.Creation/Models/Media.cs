using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Media.Commands;

namespace Nikcio.UHeadless.Media.Models;

/// <summary>
/// A base for media
/// </summary>
/// <typeparam name="TProperty"></typeparam>
public abstract class Media<TProperty> : Element<TProperty>, IMedia
    where TProperty : IProperty
{
    /// <inheritdoc/>
    protected Media(CreateMedia createMedia, IPropertyFactory<TProperty> propertyFactory) : base(createMedia.CreateElement, propertyFactory)
    {
    }
}
