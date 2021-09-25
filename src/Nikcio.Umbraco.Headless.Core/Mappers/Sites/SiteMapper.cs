using Nikcio.Umbraco.Headless.Core.Commands.Mappers.Pages;
using Nikcio.Umbraco.Headless.Core.Commands.Sites;
using Nikcio.Umbraco.Headless.Core.Models.PageModels;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites
{
    public static class SiteMapper
    {
        public static Dictionary<string, Func<ICreateSiteCommandBase, ISiteModelBase>> SiteMap { get; private set; }

        /// <summary>
        /// Adds a mapping of a content page and the corresponding model
        /// </summary>
        /// <param name="contentAlias">The alias of the content page</param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new BaseSiteModel(x)</code></param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        public static void AddMapping(string contentAlias, Func<ICreateSiteCommandBase, ISiteModelBase> intantiateFunction)
        {
            SiteMap.Add(contentAlias, intantiateFunction);
        }
    }
}
