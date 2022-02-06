using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.ContentType.Models;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    [GraphQLDescription("Represents a content item.")]
    public interface IContentGraphType : IElementGraphType
    {
        [GraphQLDescription("Gets the children of the content item that are available for the current culture.")]
        IEnumerable<ContentGraphType> Children { get; }

        [GraphQLDescription("Gets all the children of the content item, regardless of whether they are available for the current culture.")]
        IEnumerable<ContentGraphType> ChildrenForAllCultures { get; }

        [GraphQLDescription("Gets the date that the content was created.")]
        DateTime CreateDate { get; }

        [GraphQLDescription("Gets the identifier of the user who created the content item.")]
        int CreatorId { get; }

        [GraphQLDescription("Gets available culture infos.")]
        IReadOnlyDictionary<string, PublishedCultureInfo> Cultures { get; }

        [GraphQLDescription("Gets the unique identifier of the content item.")]
        int Id { get; }

        [GraphQLDescription("Gets the type of the content item (document, media...).")]
        PublishedItemType ItemType { get; }

        [GraphQLDescription("Gets the tree level of the content item.")]
        int Level { get; }

        [GraphQLDescription("Gets the name of the content item for the current culture.")]
        string Name { get; }

        [GraphQLDescription("Gets the parent of the content item.")]
        ContentGraphType Parent { get; }

        [GraphQLDescription("Gets the tree path of the content item.")]
        string Path { get; }

        [GraphQLDescription("Gets the sort order of the content item.")]
        int SortOrder { get; }

        [GraphQLDescription("Gets the identifier of the template to use to render the content item.")]
        int? TemplateId { get; }

        [GraphQLDescription("Gets the date the content item was last updated.")]
        DateTime UpdateDate { get; }

        [GraphQLDescription("Gets the URL segment of the content item for the current culture.")]
        string UrlSegment { get; }

        [GraphQLDescription("Gets the identifier of the user who last updated the content item.")]
        int WriterId { get; }

        [GraphQLDescription("Gets the url of the content item.")]
        string Url { get; }

        [GraphQLDescription("Gets the content type.")]
        new ContentTypeGraphType ContentType { get; }

        [GraphQLDescription("Gets the unique key of the element.")]
        new Guid Key { get; }

        [GraphQLDescription("Gets the properties of the element.")]
        new IEnumerable<PropertyGraphType> Properties { get; }

        [GraphQLDescription("Gets the absolute url of the content item.")]
        string AbosulteUrl { get; }
    }
}