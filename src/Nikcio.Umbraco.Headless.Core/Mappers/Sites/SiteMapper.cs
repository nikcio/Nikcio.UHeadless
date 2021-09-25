using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using System;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites
{
    public static class SiteMapper
    {
        private static Dictionary<string, Func<ICreateSiteCommandBase, ISiteModelBase>> siteMap = new();

        public static Dictionary<string, Func<ICreateSiteCommandBase, ISiteModelBase>> SiteMap { get => siteMap; private set => siteMap = value; }

        /// <summary>
        /// Adds a mapping of a content page and the corresponding model
        /// </summary>
        /// <param name="contentAlias">The alias of the content page</param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new BaseSiteModel(x)</code></param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        public static void AddMapping(string contentAlias, Func<ICreateSiteCommandBase, ISiteModelBase> intantiateFunction)
        {
            if (!siteMap.ContainsKey(contentAlias))
            {
                lock (siteMap)
                {
                    if (!siteMap.ContainsKey(contentAlias))
                    {
                        SiteMap.Add(contentAlias, intantiateFunction);
                    }
                }
            }
        }
    }
}
