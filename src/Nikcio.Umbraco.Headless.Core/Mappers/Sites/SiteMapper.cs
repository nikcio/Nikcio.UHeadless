using Nikcio.Umbraco.Headless.Core.Mappers.Bases;
using System;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites
{
    public class SiteMapper : BaseMapper, ISiteMapper
    {
        private readonly Dictionary<string, Type> siteMap = new();

        /// <inheritdoc/>
        public void AddMapping(string contentAlias, Type type)
        {
            AddMapping(contentAlias, type, siteMap);
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            return siteMap.ContainsKey(key.ToLower());
        }

        /// <inheritdoc/>
        public Type GetValue(string key)
        {
            return siteMap[key.ToLower()];
        }
    }
}
