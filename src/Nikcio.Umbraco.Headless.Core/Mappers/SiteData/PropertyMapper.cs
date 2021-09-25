using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Mappers.SiteData
{
    public static class PropertyMapper
    {
        public static Dictionary<string, Func<IPublishedProperty, IPublishedContent, IPropertyModelBase>> PropertyMap { get; private set; }

        /// <summary>
        /// Adds a mapping of a property editor and the corresponding model
        /// </summary>
        /// <param name="editorName">The name of the editor. For example: <see cref="UmbracoConstants.PropertyEditors.Aliases.BlockList"/></param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new PropertyModel(x)</code></param>
        /// <remarks>The "Default" key is the default used when no key is matched</remarks>
        public static void AddMapping(string editorName, Func<IPublishedProperty, IPublishedContent, IPropertyModelBase> intantiateFunction)
        {
            PropertyMap.Add(editorName, intantiateFunction);
        }
    }
}
