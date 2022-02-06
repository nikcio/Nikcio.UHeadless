using Nikcio.UHeadless.Models.Dtos.ContentTypes;
using Nikcio.UHeadless.Models.Dtos.Elements;
using Nikcio.UHeadless.Models.Dtos.Propreties;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Models.Dtos.Content
{
    public interface IPublishedContentGraphType : IPublishedElementGraphType
    {
        IEnumerable<PublishedContentGraphType> Children { get; }
        IEnumerable<PublishedContentGraphType> ChildrenForAllCultures { get; }
        DateTime CreateDate { get; }
        int CreatorId { get; }
        IReadOnlyDictionary<string, PublishedCultureInfo> Cultures { get; }
        int Id { get; }
        PublishedItemType ItemType { get; }
        int Level { get; }
        string Name { get; }
        PublishedContentGraphType Parent { get; }
        string Path { get; }
        int SortOrder { get; }
        int? TemplateId { get; }
        DateTime UpdateDate { get; }
        string UrlSegment { get; }
        int WriterId { get; }
        string Url { get; }
        new PublishedContentTypeGraphType ContentType { get; }
        new Guid Key { get; }
        new IEnumerable<PublishedPropertyGraphType> Properties { get; }
    }
}