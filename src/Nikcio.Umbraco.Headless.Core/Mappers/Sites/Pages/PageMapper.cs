using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels;
using System;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages
{
    public static class PageMapper
    {
        private static Dictionary<string, Func<ICreatePageCommandBase, IPageModelBase>> pageMap = new();

        public static Dictionary<string, Func<ICreatePageCommandBase, IPageModelBase>> PageMap { get => pageMap; private set => pageMap = value; }

        /// <summary>
        /// Adds a mapping of a content page and the corresponding model
        /// </summary>
        /// <param name="contentAlias">The alias of the content page</param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new BasePageModel(x)</code></param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        public static void AddMapping(string contentAlias, Func<ICreatePageCommandBase, IPageModelBase> intantiateFunction)
        {
            if (!pageMap.ContainsKey(contentAlias))
            {
                lock (pageMap)
                {
                    if (!pageMap.ContainsKey(contentAlias))
                    {
                        PageMap.Add(contentAlias, intantiateFunction);
                    }
                }
            }
        }
    }
}
