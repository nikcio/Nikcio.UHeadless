using HotChocolate;
using HotChocolate.Data;
using Nikcio.UHeadless.Basics.ContentTypes.Models;
using Nikcio.UHeadless.ContentTypes.Factories;
using Nikcio.UHeadless.ContentTypes.Models;
using Nikcio.UHeadless.Media.Commands;
using Nikcio.UHeadless.Media.Factories;
using Nikcio.UHeadless.Media.Models;
using Nikcio.UHeadless.Properties.Factories;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Basics.Media.Models {
    /// <summary>
    /// Represents a Media item
    /// </summary>
    [GraphQLDescription("Represents a Media item.")]
    public class BasicMedia : BasicMedia<BasicProperty> {
        /// <inheritdoc/>
        public BasicMedia(CreateMedia createMedia, IPropertyFactory<BasicProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IMediaFactory<BasicMedia<BasicProperty, BasicContentType>, BasicProperty> mediaFactory) : base(createMedia, propertyFactory, contentTypeFactory, mediaFactory) {
        }
    }

    /// <summary>
    /// Represents a Media item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a Media item.")]
    public class BasicMedia<TProperty> : BasicMedia<TProperty, BasicContentType>
        where TProperty : IProperty {
        /// <inheritdoc/>
        public BasicMedia(CreateMedia createMedia, IPropertyFactory<TProperty> propertyFactory, IContentTypeFactory<BasicContentType> contentTypeFactory, IMediaFactory<BasicMedia<TProperty, BasicContentType>, TProperty> mediaFactory) : base(createMedia, propertyFactory, contentTypeFactory, mediaFactory) {
        }
    }


    /// <summary>
    /// Represents a Media item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    /// <typeparam name="TContentType"></typeparam>
    [GraphQLDescription("Represents a Media item.")]
    public class BasicMedia<TProperty, TContentType> : Media<TProperty>
        where TProperty : IProperty
        where TContentType : IContentType {
        /// <inheritdoc/>
        public BasicMedia(CreateMedia createMedia, IPropertyFactory<TProperty> propertyFactory, IContentTypeFactory<TContentType> contentTypeFactory, IMediaFactory<BasicMedia<TProperty, TContentType>, TProperty> mediaFactory) : base(createMedia, propertyFactory) {
            ContentTypeFactory = contentTypeFactory;
            MediaFactory = mediaFactory;
        }

        /// <summary>
        /// Gets the identifier of the template to use to render the Media item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the template to use to render the Media item.")]
        public virtual int? TemplateId => Content?.TemplateId;

        /// <summary>
        /// Gets the parent of the Media item
        /// </summary>
        [GraphQLDescription("Gets the parent of the Media item.")]
        public virtual BasicMedia<TProperty, TContentType>? Parent => Content?.Parent != null ? MediaFactory.CreateMedia(Content.Parent, Culture) : default;

        /// <summary>
        /// Gets the type of the Media item (document, media...)
        /// </summary>
        [GraphQLDescription("Gets the type of the Media item (document, media...).")]
        public virtual PublishedItemType? ItemType => Content?.ItemType;

        /// <summary>
        /// Gets available culture infos
        /// </summary>
        [GraphQLDescription("Gets available culture infos.")]
        public virtual IReadOnlyDictionary<string, PublishedCultureInfo>? Cultures => Content?.Cultures;

        /// <summary>
        /// Gets the date the Media item was last updated
        /// </summary>
        [GraphQLDescription("Gets the date the Media item was last updated.")]
        public virtual DateTime? UpdateDate => Content?.UpdateDate;

        /// <summary>
        /// Gets the identifier of the user who last updated the Media item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the user who last updated the Media item.")]
        public virtual int? WriterId => Content?.WriterId;

        /// <summary>
        /// Gets the date that the Media was created
        /// </summary>
        [GraphQLDescription("Gets the date that the Media was created.")]
        public virtual DateTime? CreateDate => Content?.CreateDate;

        /// <summary>
        /// Gets the identifier of the user who created the Media item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the user who created the Media item.")]
        public virtual int? CreatorId => Content?.CreatorId;

        /// <summary>
        /// Gets all the children of the Media item, regardless of whether they are available for the current culture
        /// </summary>
        [GraphQLDescription("Gets all the children of the Media item, regardless of whether they are available for the current culture.")]
        public virtual IEnumerable<BasicMedia<TProperty, TContentType>?>? ChildrenForAllCultures => Content?.ChildrenForAllCultures?.Select(child => MediaFactory.CreateMedia(child, Culture));

        /// <summary>
        /// Gets the tree path of the Media item
        /// </summary>
        [GraphQLDescription("Gets the tree path of the Media item.")]
        public virtual string? Path => Content?.Path;

        /// <summary>
        /// Gets the tree level of the Media item
        /// </summary>
        [GraphQLDescription("Gets the tree level of the Media item.")]
        public virtual int? Level => Content?.Level;

        /// <summary>
        /// Gets the sort order of the Media item
        /// </summary>
        [GraphQLDescription("Gets the sort order of the Media item.")]
        public virtual int? SortOrder => Content?.SortOrder;

        /// <summary>
        /// Gets the URL segment of the Media item for the current culture
        /// </summary>
        [GraphQLDescription("Gets the URL segment of the Media item for the current culture.")]
        public virtual string? UrlSegment => Content?.UrlSegment;

        /// <summary>
        /// Gets the url of the Media item
        /// </summary>
        [GraphQLDescription("Gets the url of the Media item.")]
        public virtual string? Url => Content?.Url();

        /// <summary>
        /// Gets the absolute url of the Media item
        /// </summary>
        [GraphQLDescription("Gets the absolute url of the Media item.")]
        public virtual string? AbsoluteUrl => Content?.Url(Culture, UrlMode.Absolute);

        /// <summary>
        /// Gets the name of the Media item for the current culture
        /// </summary>
        [GraphQLDescription("Gets the name of the Media item for the current culture.")]
        public virtual string? Name => Content?.Name;

        /// <summary>
        /// Gets the unique identifier of the Media item
        /// </summary>
        [GraphQLDescription("Gets the unique identifier of the Media item.")]
        public virtual int? Id => Content?.Id;

        /// <summary>
        /// Gets the children of the Media item that are available for the current cultur
        /// </summary>
        [GraphQLDescription("Gets the children of the Media item that are available for the current culture.")]
        public virtual IEnumerable<BasicMedia<TProperty, TContentType>?>? Children => Content?.Children?.Select(child => MediaFactory.CreateMedia(child, Culture));


        /// <inheritdoc/>
        [GraphQLDescription("Gets the content type.")]
        public virtual TContentType? ContentType => Content != null ? ContentTypeFactory.CreateContentType(Content.ContentType) : default;

        /// <inheritdoc/>
        [GraphQLDescription("Gets the unique key of the element.")]
        public virtual Guid? Key => Content?.Key;

        /// <inheritdoc/>
        [GraphQLDescription("Gets the properties of the element.")]
        [UseFiltering]
        public virtual IEnumerable<TProperty?>? Properties => Content != null ? PropertyFactory.CreateProperties(Content, Culture) : default;

        /// <summary>
        /// A factory for media
        /// </summary>
        protected virtual IMediaFactory<BasicMedia<TProperty, TContentType>, TProperty> MediaFactory { get; }

        /// <summary>
        /// A factory for content type
        /// </summary>
        protected virtual IContentTypeFactory<TContentType> ContentTypeFactory { get; }
    }
}
