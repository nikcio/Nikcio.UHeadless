﻿using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Models;
using Nikcio.UHeadless.UmbracoElements.Elements.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Factories
{
    /// <inheritdoc/>
    public class ContentFactory<TContent, TProperty> : IContentFactory<TContent, TProperty>
            where TContent : IContent<TProperty>
            where TProperty : IProperty
    {
        /// <summary>
        /// A factory that can create object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public ContentFactory(IDependencyReflectorFactory dependencyReflectorFactory)
        {
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual TContent? CreateContent(IPublishedContent content, string? culture)
        {
            var createElementCommand = new CreateElement(content, culture);
            var createContentCommand = new CreateContent(content, culture, createElementCommand);

            var createdContent = dependencyReflectorFactory.GetReflectedType<IContent<TProperty>>(typeof(TContent), new object[] { createContentCommand });
            if (createdContent == null)
            {
                return default;
            }
            return (TContent)createdContent;
        }
    }
}
