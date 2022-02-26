using HotChocolate;
using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
[GraphQLDescription("Represents a content item.")]
    public class ContentGraphType<TPropertyGraphType> : ElementGraphType<TPropertyGraphType>, IContentGraphTypeBase<TPropertyGraphType>
        where TPropertyGraphType : IPropertyGraphTypeBase
    {
        [GraphQLDescription("Gets the identifier of the template to use to render the content item.")]
        public int? TemplateId => Content.TemplateId;

        [GraphQLDescription("Gets the parent of the content item.")]
        public ContentGraphType<TPropertyGraphType> Parent => SetInitalValues(Mapper.Map<ContentGraphType<TPropertyGraphType>>(Content.Parent), PropertyFactory, Culture, Mapper) as ContentGraphType<TPropertyGraphType>;

        [GraphQLDescription("Gets the type of the content item (document, media...).")]
        public PublishedItemType ItemType => Content.ItemType;

        [GraphQLDescription("Gets available culture infos.")]
        public IReadOnlyDictionary<string, PublishedCultureInfo> Cultures => Content.Cultures;

        [GraphQLDescription("Gets the date the content item was last updated.")]
        public DateTime UpdateDate => Content.UpdateDate;

        [GraphQLDescription("Gets the identifier of the user who last updated the content item.")]
        public int WriterId => Content.WriterId;

        [GraphQLDescription("Gets the date that the content was created.")]
        public DateTime CreateDate => Content.CreateDate;

        [GraphQLDescription("Gets the identifier of the user who created the content item.")]
        public int CreatorId => Content.CreatorId;

        [GraphQLDescription("Gets all the children of the content item, regardless of whether they are available for the current culture.")]
        public IEnumerable<ContentGraphType<TPropertyGraphType>> ChildrenForAllCultures => Mapper.Map<IEnumerable<ContentGraphType<TPropertyGraphType>>>(Content.ChildrenForAllCultures).Select(item => SetInitalValues(item, PropertyFactory, Culture, Mapper) as ContentGraphType<TPropertyGraphType>);

        [GraphQLDescription("Gets the tree path of the content item.")]
        public string Path => Content.Path;

        [GraphQLDescription("Gets the tree level of the content item.")]
        public int Level => Content.Level;

        [GraphQLDescription("Gets the sort order of the content item.")]
        public int SortOrder => Content.SortOrder;

        [GraphQLDescription("Gets the URL segment of the content item for the current culture.")]
        public string UrlSegment => Content.UrlSegment;

        [GraphQLDescription("Gets the url of the content item.")]
        public string Url => Content.Url();

        [GraphQLDescription("Gets the absolute url of the content item.")]
        public string AbosulteUrl => Content.Url(Culture, UrlMode.Absolute);

        [GraphQLDescription("Gets the name of the content item for the current culture.")]
        public string Name => Content.Name;

        [GraphQLDescription("Gets the unique identifier of the content item.")]
        public int Id => Content.Id;

        [GraphQLDescription("Gets the children of the content item that are available for the current culture.")]
        public IEnumerable<ContentGraphType<TPropertyGraphType>> Children => Mapper.Map<IEnumerable<ContentGraphType<TPropertyGraphType>>>(Content.Children).Select(item => SetInitalValues(item, PropertyFactory, Culture, Mapper) as ContentGraphType<TPropertyGraphType>);
    }
}
