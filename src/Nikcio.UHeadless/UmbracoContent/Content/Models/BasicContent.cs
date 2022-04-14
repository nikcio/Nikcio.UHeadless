﻿using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.UmbracoContent.Content.Commands;
using Nikcio.UHeadless.UmbracoContent.Content.Factories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Factories;
using Nikcio.UHeadless.UmbracoElements.ContentTypes.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    /// <summary>
    /// Represents a content item
    /// </summary>
    [GraphQLDescription("Represents a content item.")]
    public class BasicContent : BasicContent<BasicProperty>
    {
        /// <inheritdoc/>
        public BasicContent(CreateContent createContent, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<BasicProperty, BasicContentType>, BasicProperty> contentFactory) : base(createContent, propertyFactory, contentTypeFactory, contentFactory)
        {
        }
    }

    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public class BasicContent<TProperty> : BasicContent<TProperty, BasicContentType>
        where TProperty : IProperty
    {
        /// <inheritdoc/>
        public BasicContent(CreateContent createContent, IPropertyFactory<TProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IContentFactory<BasicContent<TProperty, BasicContentType>, TProperty> contentFactory) : base(createContent, propertyFactory, contentTypeFactory, contentFactory)
        {
        }
    }

    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TContentType"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public class BasicContent<TProperty, TContentType> : Content<TProperty>
        where TProperty : IProperty
        where TContentType : IContentType
    {
        /// <inheritdoc/>
        public BasicContent(CreateContent createContent, IPropertyFactory<TProperty> propertyFactory, IContentTypeFactory<TContentType> contentTypeFactory, IContentFactory<BasicContent<TProperty, TContentType>, TProperty> contentFactory) : base(createContent, propertyFactory)
        {
            ContentFactory = contentFactory;
            ContentTypeFactory = contentTypeFactory;
        }

        /// <summary>
        /// Gets the identifier of the template to use to render the content item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the template to use to render the content item.")]
        public virtual int? TemplateId => Content.TemplateId;

        /// <summary>
        /// Gets the parent of the content item
        /// </summary>
        [GraphQLDescription("Gets the parent of the content item.")]
        public virtual BasicContent<TProperty, TContentType>? Parent => ContentFactory.CreateContent(Content.Parent, Culture);

        /// <summary>
        /// Gets the type of the content item (document, media...)
        /// </summary>
        [GraphQLDescription("Gets the type of the content item (document, media...).")]
        public virtual PublishedItemType? ItemType => Content?.ItemType;

        /// <summary>
        /// Gets available culture infos
        /// </summary>
        [GraphQLDescription("Gets available culture infos.")]
        public virtual IReadOnlyDictionary<string, PublishedCultureInfo>? Cultures => Content?.Cultures;

        /// <summary>
        /// Gets the date the content item was last updated
        /// </summary>
        [GraphQLDescription("Gets the date the content item was last updated.")]
        public virtual DateTime? UpdateDate => Content?.UpdateDate;

        /// <summary>
        /// Gets the identifier of the user who last updated the content item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the user who last updated the content item.")]
        public virtual int? WriterId => Content?.WriterId;

        /// <summary>
        /// Gets the date that the content was created
        /// </summary>
        [GraphQLDescription("Gets the date that the content was created.")]
        public virtual DateTime? CreateDate => Content?.CreateDate;

        /// <summary>
        /// Gets the identifier of the user who created the content item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the user who created the content item.")]
        public virtual int? CreatorId => Content?.CreatorId;

        /// <summary>
        /// Gets all the children of the content item, regardless of whether they are available for the current culture
        /// </summary>
        [GraphQLDescription("Gets all the children of the content item, regardless of whether they are available for the current culture.")]
        public virtual IEnumerable<BasicContent<TProperty, TContentType>?> ChildrenForAllCultures => Content.ChildrenForAllCultures.Select(child => ContentFactory.CreateContent(child, Culture));

        /// <summary>
        /// Gets the tree path of the content item
        /// </summary>
        [GraphQLDescription("Gets the tree path of the content item.")]
        public virtual string? Path => Content?.Path;

        /// <summary>
        /// Gets the tree level of the content item
        /// </summary>
        [GraphQLDescription("Gets the tree level of the content item.")]
        public virtual int? Level => Content?.Level;

        /// <summary>
        /// Gets the sort order of the content item
        /// </summary>
        [GraphQLDescription("Gets the sort order of the content item.")]
        public virtual int? SortOrder => Content?.SortOrder;

        /// <summary>
        /// Gets the URL segment of the content item for the current culture
        /// </summary>
        [GraphQLDescription("Gets the URL segment of the content item for the current culture.")]
        public virtual string? UrlSegment => Content?.UrlSegment;

        /// <summary>
        /// Gets the url of the content item
        /// </summary>
        [GraphQLDescription("Gets the url of the content item.")]
        public virtual string? Url => Content?.Url();

        /// <summary>
        /// Gets the absolute url of the content item
        /// </summary>
        [GraphQLDescription("Gets the absolute url of the content item.")]
        public virtual string? AbsoluteUrl => Content?.Url(Culture, UrlMode.Absolute);

        /// <summary>
        /// Gets the name of the content item for the current culture
        /// </summary>
        [GraphQLDescription("Gets the name of the content item for the current culture.")]
        public virtual string? Name => Content?.Name;

        /// <summary>
        /// Gets the unique identifier of the content item
        /// </summary>
        [GraphQLDescription("Gets the unique identifier of the content item.")]
        public virtual int? Id => Content?.Id;

        /// <summary>
        /// Gets the children of the content item that are available for the current cultur
        /// </summary>
        [GraphQLDescription("Gets the children of the content item that are available for the current culture.")]
        public virtual IEnumerable<BasicContent<TProperty, TContentType>?> Children => Content.Children.Select(child => ContentFactory.CreateContent(child, Culture));

        /// <inheritdoc/>
        [GraphQLDescription("Gets the content type.")]
        public virtual TContentType? ContentType => ContentTypeFactory.CreateContentType(Content.ContentType);

        /// <inheritdoc/>
        [GraphQLDescription("Gets the unique key of the element.")]
        public virtual Guid Key => Content.Key;

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of the element.")]
        [UseFiltering]
        public virtual IEnumerable<TProperty?> Properties => PropertyFactory.CreateProperties(Content, Culture);

        /// <summary>
        /// The content factory
        /// </summary>
        protected virtual IContentFactory<BasicContent<TProperty, TContentType>, TProperty> ContentFactory { get; }

        /// <summary>
        /// The content type factory
        /// </summary>
        protected virtual IContentTypeFactory<TContentType> ContentTypeFactory { get; }
    }

}
