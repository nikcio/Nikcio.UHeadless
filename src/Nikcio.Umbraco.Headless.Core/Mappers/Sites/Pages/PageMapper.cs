using Nikcio.Umbraco.Headless.Core.Mappers.Bases;
using System;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages
{
    public class PageMapper : BaseMapper, IPageMapper
    {
        private readonly Dictionary<string, Type> pageMap = new();

        /// <inheritdoc/>
        public void AddMapping(string contentAlias, Type type)
        {
            AddMapping(contentAlias, type, pageMap);
        }

        /// <inheritdoc/>
        public bool ContainsKey(string key)
        {
            return pageMap.ContainsKey(key.ToLower());
        }

        /// <inheritdoc/>
        public Type GetValue(string key)
        {
            return pageMap[key.ToLower()];
        }
    }
}
