using Nikcio.UHeadless.Base.Elements.Models;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Content.Commands;

namespace Nikcio.UHeadless.Content.Models;

/// <summary>
/// A base for content
/// </summary>
/// <typeparam name="TProperty"></typeparam>
public abstract class Content<TProperty> : Element<TProperty>, IContent
    where TProperty : IProperty
{
    /// <inheritdoc/>
    protected Content(CreateContent createContent, IPropertyFactory<TProperty> propertyFactory) : base(createContent.CreateElement, propertyFactory)
    {
    }

    /// <inheritdoc/>
    public virtual object? Redirect { get; set; }
}
