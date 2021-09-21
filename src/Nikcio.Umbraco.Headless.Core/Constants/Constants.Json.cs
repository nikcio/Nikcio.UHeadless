using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Constants
{
    public static partial class Constants
    {
        public static class Json
        {
            public static readonly string PublishedContentNamespace = typeof(IPublishedContent).Namespace;

            public static readonly IEnumerable<string> DefaultJsonIgnore = new List<string>()
            {
                IgnoredProperties.CompositionAliases,
                IgnoredProperties.ContentSet,
                IgnoredProperties.ContentType,
                IgnoredProperties.PropertyTypes,
                IgnoredProperties.Properties,
                IgnoredProperties.Parrent,
                IgnoredProperties.Children,
                IgnoredProperties.DocumentTypeId,
                IgnoredProperties.WriterName,
                IgnoredProperties.CreatorName,
                IgnoredProperties.Cultures,
                IgnoredProperties.ChildrenForAllCultures,
                IgnoredProperties.UrlSegment,
                IgnoredProperties.WriterId,
                IgnoredProperties.CreatorId,
                IgnoredProperties.CreateDate,
                IgnoredProperties.UpdateDate,
                IgnoredProperties.Version,
                IgnoredProperties.SortOrder,
                IgnoredProperties.IsDraft,
                IgnoredProperties.ItemType,
                IgnoredProperties.ModelClrType,
                IgnoredProperties.ClrType,
                IgnoredProperties.Datatype,
                IgnoredProperties.IsUserProperty,
                IgnoredProperties.Variations,
                IgnoredProperties.CacheLevel
            };

            public static class IgnoredProperties
            {
                public const string CompositionAliases = nameof(IPublishedContent.ContentType.CompositionAliases);
                public const string ContentSet = "ContentSet";
                public const string ContentType = nameof(IPublishedContent.ContentType);
                public const string PropertyTypes = nameof(IPublishedContent.ContentType.PropertyTypes);
                public const string Properties = nameof(IPublishedContent.Properties);
                public const string Parrent = nameof(IPublishedContent.Parent);
                public const string Children = nameof(IPublishedContent.Children);
                public const string DocumentTypeId = "DocumentTypeId";
                public const string WriterName = "WriterName";
                public const string CreatorName = "CreatorName";
                public const string Cultures = nameof(IPublishedContent.Cultures);
                public const string ChildrenForAllCultures = nameof(IPublishedContent.ChildrenForAllCultures);
                public const string UrlSegment = nameof(IPublishedContent.UrlSegment);
                public const string WriterId = nameof(IPublishedContent.WriterId);
                public const string CreatorId = nameof(IPublishedContent.CreatorId);
                public const string CreateDate = nameof(IPublishedContent.CreateDate);
                public const string UpdateDate = nameof(IPublishedContent.UpdateDate);
                public const string Version = "Version";
                public const string SortOrder = nameof(IPublishedContent.SortOrder);
                public const string IsDraft = "IsDraft";
                public const string ItemType = nameof(IPublishedContent.ItemType);
                public const string ModelClrType = nameof(IPublishedPropertyType.ModelClrType);
                public const string ClrType = nameof(IPublishedPropertyType.ClrType);
                public const string Datatype = nameof(IPublishedPropertyType.DataType);
                public const string IsUserProperty = nameof(IPublishedPropertyType.IsUserProperty);
                public const string Variations = nameof(IPublishedPropertyType.Variations);
                public const string CacheLevel = nameof(IPublishedPropertyType.CacheLevel);
            }
        }
    }
}