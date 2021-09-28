using Nikcio.Umbraco.Headless.Core.Mappers.Bases;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites
{
    public class SiteMapper : BaseMapper, ISiteMapper
    {
        private readonly Dictionary<string, string> siteMap = new();

        /// <inheritdoc/>
        public void AddMapping<TType>(string contentAlias) where TType : class, ISiteModelBase
        {
            AddMapping<TType>(contentAlias, siteMap);
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            return siteMap.ContainsKey(key.ToLower());
        }

        /// <inheritdoc/>
        public string GetValue(string key)
        {
            return siteMap[key.ToLower()];
        }
    }
}
