using Nikcio.Umbraco.Headless.Core.Commands.Sites.Pages.PageData;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;
using System;
using System.Collections.Generic;
using UmbracoConstants = Umbraco.Cms.Core.Constants;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData
{
    public static class PropertyMapper
    {
        private static Dictionary<string, Func<ICreatePropertyCommandBase, IPropertyModelBase>> editorPropertyMap = new();
        private static Dictionary<string, Func<ICreatePropertyCommandBase, IPropertyModelBase>> aliasPropertyMap = new();

        /// <summary>
        /// Adds a mapping of a property editor and the corresponding model
        /// </summary>
        /// <param name="editorName">The name of the editor. For example: <see cref="UmbracoConstants.PropertyEditors.Aliases.BlockList"/></param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new PropertyModel(x)</code></param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        public static void AddEditorMapping(string editorName, Func<ICreatePropertyCommandBase, IPropertyModelBase> intantiateFunction)
        {
            editorName = editorName.ToLower();
            if (!editorPropertyMap.ContainsKey(editorName))
            {
                lock (editorPropertyMap)
                {
                    if (!editorPropertyMap.ContainsKey(editorName))
                    {
                        editorPropertyMap.Add(editorName, intantiateFunction);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a key is present in the dictionary
        /// </summary>
        /// <param name="editorName"></param>
        /// <returns></returns>
        public static bool ContainsEditor(string editorName)
        {
            return editorPropertyMap.ContainsKey(editorName.ToLower());
        }

        /// <summary>
        /// Gets a value for a key in the editor dictornary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Func<ICreatePropertyCommandBase, IPropertyModelBase> GetEditorValue(string key)
        {
            return editorPropertyMap[key.ToLower()];
        }

        /// <summary>
        /// Adds a mapping of a property editor and the corresponding model
        /// </summary>
        /// <param name="contentTypeAlias">The name of the editor. For example: <see cref="UmbracoConstants.PropertyEditors.Aliases.BlockList"/></param>
        /// <param name="intantiateFunction">The function to instantiate the model. For example: <code>(x, y) => new PropertyModel(x)</code></param>
        /// <remarks>The <see cref="Constants.Constants.Factories.DefaultKey"/> key is the default used when no key is matched</remarks>
        public static void AddAliasMapping(string contentTypeAlias, string propertyTypeAlias, Func<ICreatePropertyCommandBase, IPropertyModelBase> intantiateFunction)
        {
            contentTypeAlias = contentTypeAlias.ToLower();
            propertyTypeAlias = propertyTypeAlias.ToLower();
            if (!ContainsAlias(contentTypeAlias, propertyTypeAlias))
            {
                lock (aliasPropertyMap)
                {
                    if (!ContainsAlias(contentTypeAlias, propertyTypeAlias))
                    {
                        aliasPropertyMap.Add(contentTypeAlias+propertyTypeAlias, intantiateFunction);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a key is present in the dictornary
        /// </summary>
        /// <param name="editorName"></param>
        /// <returns></returns>
        public static bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias)
        {
            return aliasPropertyMap.ContainsKey((contentTypeAlias+propertyTypeAlias).ToLower());
        }

        /// <summary>
        /// Gets a value for a key in the editor dictornary
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Func<ICreatePropertyCommandBase, IPropertyModelBase> GetAliasValue(string contentTypeAlias, string propertyAlias)
        {
            return aliasPropertyMap[(contentTypeAlias+propertyAlias).ToLower()];
        }
    }
}
