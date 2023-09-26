﻿using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.NestedContent;

/// <summary>
/// Represents nested content
/// </summary>
public class NestedContentModel : PropertyValue
{
    /// <summary>
    /// Gets the elements of a nested content
    /// </summary>
    public virtual List<NestedContentElementModel>? Elements { get; set; }

    /// <inheritdoc/>
    public NestedContentModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue)
    {
        var propertyValue = createPropertyValue.Property.Value<IEnumerable<IPublishedElement>?>(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (propertyValue == null)
        {
            return;
        }

        Elements = propertyValue?.Select(element =>
        {
            var type = typeof(NestedContentElementModel);
            return dependencyReflectorFactory.GetReflectedType<NestedContentElementModel>(type, new object[] { new CreateNestedContentElement(createPropertyValue.Content, element, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback) });
        }).OfType<NestedContentElementModel>().ToList();
    }
}
