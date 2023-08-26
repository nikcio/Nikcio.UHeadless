﻿using Nikcio.UHeadless.Base.Properties.Factories;
using Nikcio.UHeadless.Base.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Repositories;

/// <inheritdoc/>
public class PropertyRespository<TProperty> : IPropertyRespository<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// A factory for creating properties
    /// </summary>
    protected readonly IPropertyFactory<TProperty> propertyFactory;

    /// <inheritdoc/>
    public PropertyRespository(IPropertyFactory<TProperty> propertyFactory)
    {
        this.propertyFactory = propertyFactory;
    }

    /// <inheritdoc/>
    public virtual IEnumerable<TProperty?> GetProperties(IPublishedContent content, string? culture, string? segment, Fallback? fallback)
    {
        return content.Properties.Select(IPublishedProperty => propertyFactory.GetProperty(IPublishedProperty, content, culture, segment, fallback));
    }
}