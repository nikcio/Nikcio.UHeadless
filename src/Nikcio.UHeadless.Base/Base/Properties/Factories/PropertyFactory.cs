using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Factories;

/// <inheritdoc/>
public class PropertyFactory<TProperty> : IPropertyFactory<TProperty>
    where TProperty : IProperty
{
    /// <summary>
    /// A factory for creating objects with DI
    /// </summary>
    protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

    /// <summary>
    /// The published value fallback
    /// </summary>
    protected readonly IPublishedValueFallback publishedValueFallback;

    /// <inheritdoc/>
    public PropertyFactory(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedValueFallback publishedValueFallback)
    {
        this.dependencyReflectorFactory = dependencyReflectorFactory;
        this.publishedValueFallback = publishedValueFallback;
    }

    /// <inheritdoc/>
    public virtual TProperty? GetProperty(IPublishedProperty property, IPublishedContent publishedContent, string? culture, string? segment, Fallback? fallback)
    {
        var createPropertyCommand = new CreateProperty(property, culture, publishedContent, segment, publishedValueFallback, fallback);

        var createdProperty = dependencyReflectorFactory.GetReflectedType<IProperty>(typeof(TProperty), new object[] { createPropertyCommand });
        return createdProperty == null ? default : (TProperty) createdProperty;
    }

    /// <inheritdoc/>
    public virtual IEnumerable<TProperty?> CreateProperties(IPublishedContent publishedContent, string? culture, string? segment, Fallback? fallback)
    {
        return publishedContent.Properties.Select(IPublishedProperty => GetProperty(IPublishedProperty, publishedContent, culture, segment, fallback));
    }
}
