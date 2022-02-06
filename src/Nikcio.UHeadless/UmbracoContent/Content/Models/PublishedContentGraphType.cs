using Nikcio.UHeadless.UmbracoContent.Elements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.UmbracoContent.Content.Models
{
    public class PublishedContentGraphType : PublishedElementGraphType, IPublishedContentGraphType
    {
        public int? TemplateId => Content.TemplateId;

        public PublishedContentGraphType Parent => SetInitalValues(Mapper.Map<PublishedContentGraphType>(Content.Parent), propertyFactory, Culture, Mapper) as PublishedContentGraphType;

        public PublishedItemType ItemType => Content.ItemType;

        public IReadOnlyDictionary<string, PublishedCultureInfo> Cultures => Content.Cultures;

        public DateTime UpdateDate => Content.UpdateDate;

        public int WriterId => Content.WriterId;

        public DateTime CreateDate => Content.CreateDate;

        public int CreatorId => Content.CreatorId;

        public IEnumerable<PublishedContentGraphType> ChildrenForAllCultures => Mapper.Map<IEnumerable<PublishedContentGraphType>>(Content.ChildrenForAllCultures).Select(item => SetInitalValues(item, propertyFactory, Culture, Mapper) as PublishedContentGraphType);

        public string Path => Content.Path;

        public int Level => Content.Level;

        public int SortOrder => Content.SortOrder;

        public string UrlSegment => Content.UrlSegment;

        public string Url => Content.Url();

        public string Name => Content.Name;

        public int Id => Content.Id;

        public IEnumerable<PublishedContentGraphType> Children => Mapper.Map<IEnumerable<PublishedContentGraphType>>(Content.Children).Select(item => SetInitalValues(item, propertyFactory, Culture, Mapper) as PublishedContentGraphType);
    }
}
