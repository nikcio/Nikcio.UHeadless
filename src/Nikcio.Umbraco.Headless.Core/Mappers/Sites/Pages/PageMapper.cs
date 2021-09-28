using Nikcio.Umbraco.Headless.Core.Mappers.Bases;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages
{
    public class PageMapper : BaseMapper, IPageMapper
    {
        private readonly Dictionary<string, string> pageMap = new();

        /// <inheritdoc/>
        public void AddMapping<TType>(string contentAlias) where TType : class, IPageModelBase
        {
            AddMapping<TType>(contentAlias, pageMap);
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            return pageMap.ContainsKey(key.ToLower());
        }

        /// <inheritdoc/>
        public string GetValue(string key)
        {
            return pageMap[key.ToLower()];
        }
    }
}
