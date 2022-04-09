using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    /// <summary>
    /// Represents a content item
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a content item.")]
    public class BasicContent<TProperty> : BasicElement<TProperty>, IContent<TProperty>
        where TProperty : IProperty
    {
        /// <summary>
        /// Gets the identifier of the template to use to render the content item
        /// </summary>
        [GraphQLDescription("Gets the identifier of the template to use to render the content item.")]
        public virtual int? TemplateId => Content?.TemplateId;

        /// <summary>
        /// Gets the parent of the content item
        /// </summary>
        [GraphQLDescription("Gets the parent of the content item.")]
        public virtual BasicContent<TProperty>? Parent => throw new NotImplementedException(); //TODO //SetInitalValues(Mapper?.Map<BasicContent<TProperty>>(BasicContent?.Parent), PropertyFactory, Culture, Mapper) as BasicContent<TProperty>;

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
        public virtual IEnumerable<BasicContent<TProperty>>? ChildrenForAllCultures => throw new NotImplementedException(); //TODO //Mapper?.Map<IEnumerable<BasicContent<TProperty>>>(BasicContent?.ChildrenForAllCultures)?.Select(item => SetInitalValues(item, PropertyFactory, Culture, Mapper) as BasicContent<TProperty>).OfType<BasicContent<TProperty>>();

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
        public virtual IEnumerable<BasicContent<TProperty>>? Children => throw new NotImplementedException(); //TODO //Mapper?.Map<IEnumerable<BasicContent<TProperty>>>(BasicContent?.Children)?.Select(item => SetInitalValues(item, PropertyFactory, Culture, Mapper) as BasicContent<TProperty>).OfType<BasicContent<TProperty>>();
    }
}
