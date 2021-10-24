using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.Umbraco.Headless.Core.Constants
{
    public static partial class Constants
    {
        public static class Json
        {
            public static readonly string PublishedContentNamespace = typeof(IPublishedContent).Namespace;

            public static readonly IEnumerable<string> DefaultJsonIgnore = new List<string>
            {
                IgnoredProperties.CompositionAliases,
                IgnoredProperties.ContentType,
                IgnoredProperties.PropertyTypes,
                IgnoredProperties.Properties,
                IgnoredProperties.Parrent,
                IgnoredProperties.Children,
                IgnoredProperties.Cultures,
                IgnoredProperties.ChildrenForAllCultures,
                IgnoredProperties.UrlSegment,
                IgnoredProperties.WriterId,
                IgnoredProperties.CreatorId,
                IgnoredProperties.CreateDate,
                IgnoredProperties.UpdateDate,
                IgnoredProperties.SortOrder,
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
                public static readonly string CompositionAliases = nameof(IPublishedContent.ContentType.CompositionAliases);
                public static readonly string ContentType = nameof(IPublishedContent.ContentType);
                public static readonly string PropertyTypes = nameof(IPublishedContent.ContentType.PropertyTypes);
                public static readonly string Properties = nameof(IPublishedContent.Properties);
                public static readonly string Parrent = nameof(IPublishedContent.Parent);
                public static readonly string Children = nameof(IPublishedContent.Children);
                public static readonly string Cultures = nameof(IPublishedContent.Cultures);
                public static readonly string ChildrenForAllCultures = nameof(IPublishedContent.ChildrenForAllCultures);
                public static readonly string UrlSegment = nameof(IPublishedContent.UrlSegment);
                public static readonly string WriterId = nameof(IPublishedContent.WriterId);
                public static readonly string CreatorId = nameof(IPublishedContent.CreatorId);
                public static readonly string CreateDate = nameof(IPublishedContent.CreateDate);
                public static readonly string UpdateDate = nameof(IPublishedContent.UpdateDate);
                public static readonly string SortOrder = nameof(IPublishedContent.SortOrder);
                public static readonly string ItemType = nameof(IPublishedContent.ItemType);
                public static readonly string ModelClrType = nameof(IPublishedPropertyType.ModelClrType);
                public static readonly string ClrType = nameof(IPublishedPropertyType.ClrType);
                public static readonly string Datatype = nameof(IPublishedPropertyType.DataType);
                public static readonly string IsUserProperty = nameof(IPublishedPropertyType.IsUserProperty);
                public static readonly string Variations = nameof(IPublishedPropertyType.Variations);
                public static readonly string CacheLevel = nameof(IPublishedPropertyType.CacheLevel);
            }
        }
    }
}