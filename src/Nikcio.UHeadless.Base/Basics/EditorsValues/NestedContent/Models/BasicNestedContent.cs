﻿using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.NestedContent.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.NestedContent.Models {
    /// <summary>
    /// Represents nested content
    /// </summary>
    [GraphQLDescription("Represents nested content.")]
    public class BasicNestedContent : BasicNestedContent<BasicNestedContentElement> {
        /// <inheritdoc/>
        public BasicNestedContent(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents nested content
    /// </summary>
    /// <typeparam name="TNestedContentElement"></typeparam>
    [GraphQLDescription("Represents nested content.")]
    public class BasicNestedContent<TNestedContentElement> : PropertyValue
        where TNestedContentElement : NestedContentElement {
        /// <summary>
        /// Gets the elements of a nested content
        /// </summary>
        [GraphQLDescription("Gets the elements of a nested content.")]
        public virtual List<TNestedContentElement>? Elements { get; set; }

        /// <inheritdoc/>
        public BasicNestedContent(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var elements = (createPropertyValue.Property.GetValue() as IEnumerable<IPublishedElement>)?.ToList();
            if (elements == null) {
                return;
            }

            Elements = elements.Select(element => {
                var type = typeof(TNestedContentElement);
                return dependencyReflectorFactory.GetReflectedType<TNestedContentElement>(type, new object[] { new CreateNestedContentElement(createPropertyValue.Content, element, createPropertyValue.Culture) });
            }).OfType<TNestedContentElement>().ToList();
        }
    }
}
