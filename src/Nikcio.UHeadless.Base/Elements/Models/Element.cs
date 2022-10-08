using Nikcio.UHeadless.Base.Elements.Commands;
using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Elements.Models;

/// <inheritdoc/>
public abstract class Element<TProperty> : IElement<TProperty>
    where TProperty : IProperty
{
    /// <inheritdoc/>
    protected Element(CreateElement createElement, IPropertyFactory<TProperty> propertyFactory)
    {
        Content = createElement.Content;
        Culture = createElement.Culture;
        PropertyFactory = propertyFactory;
    }

    /// <summary>
    /// The propertyFactory
    /// </summary>
    protected virtual IPropertyFactory<TProperty> PropertyFactory { get; }

    /// <summary>
    /// The content
    /// </summary>
    protected virtual IPublishedContent? Content { get; }

    /// <summary>
    /// The culture
    /// </summary>
    protected virtual string? Culture { get; }
}
