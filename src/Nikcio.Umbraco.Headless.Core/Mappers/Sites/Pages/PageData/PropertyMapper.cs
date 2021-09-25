using Nikcio.Umbraco.Headless.Core.Commands.PropertyMappers;
using Nikcio.Umbraco.Headless.Core.Models.SiteData.Elements;
using System;
using System.Collections.Generic;
using Umbraco.Cms.Core.Models.PublishedContent;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Mappers.SiteData
{
    public static class PropertyMapper
    {
        private static Dictionary<string, Func<ICreatePropertyCommandBase, IPropertyModelBase>> propertyMap = new();

        public static Dictionary<string, Func<ICreatePropertyCommandBase, IPropertyModelBase>> PropertyMap { get => propertyMap; private set => propertyMap = value; }

        /// <summary>
        /// Adds a mapping of a property editor and the corresponding model
        /// </summary>
        /// <param name="editorName">The name of the editor. For example: <see cref="UmbracoConstants.PropertyEditors.Aliases.BlockList"/></param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new PropertyModel(x)</code></param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        public static void AddMapping(string editorName, Func<ICreatePropertyCommandBase, IPropertyModelBase> intantiateFunction)
        {
            if (!propertyMap.ContainsKey(editorName))
            {
                lock (propertyMap)
                {
                    if (!propertyMap.ContainsKey(editorName))
                    {
                        PropertyMap.Add(editorName, intantiateFunction);
                    }
                }
            }
        }
    }
}
