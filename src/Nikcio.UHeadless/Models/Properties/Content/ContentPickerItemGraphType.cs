using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Models.Properties.Content
{
    public class ContentPickerItemGraphType
    {
        public int? TemplateId => Content.TemplateId;

        public PublishedItemType ItemType => Content.ItemType;

        public IReadOnlyDictionary<string, PublishedCultureInfo> Cultures => Content.Cultures;

        public DateTime UpdateDate => Content.UpdateDate;

        public int WriterId => Content.WriterId;

        public DateTime CreateDate => Content.CreateDate;

        public int CreatorId => Content.CreatorId;

        public string Path => Content.Path;

        public int Level => Content.Level;

        public int SortOrder => Content.SortOrder;

        public string UrlSegment => Content.UrlSegment;

        public string Url => Content.Url();

        public string Name => Content.Name;

        public int Id => Content.Id;

        public Guid Key => Content.Key;

        [GraphQLIgnore]
        public IPublishedContent Content { get; set; }

        public ContentPickerItemGraphType(IPublishedContent content)
        {
            Content = content;
        }
    }
}
