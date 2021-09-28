using Nikcio.Umbraco.Headless.Core.Mappers.Bases;
using System;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData
{
    public class PropertyMapper : BaseMapper, IPropertyMapper
    {
        private readonly Dictionary<string, Type> editorPropertyMap = new();
        private readonly Dictionary<string, Type> aliasPropertyMap = new();

        /// <inheritdoc/>
        public void AddEditorMapping(string editorName, Type type)
        {
            AddMapping(editorName, type, editorPropertyMap);
        }

        /// <inheritdoc/>
        public void AddAliasMapping(string contentTypeAlias, string propertyTypeAlias, Type type)
        {
            AddMapping(contentTypeAlias + propertyTypeAlias, type, aliasPropertyMap);
        }

        /// <inheritdoc/>
        public bool ContainsEditor(string editorName)
        {
            return editorPropertyMap.ContainsKey(editorName.ToLower());
        }

        /// <inheritdoc/>
        public bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias)
        {
            return aliasPropertyMap.ContainsKey((contentTypeAlias + propertyTypeAlias).ToLower());
        }

        /// <inheritdoc/>
        public Type GetEditorValue(string key)
        {
            return editorPropertyMap[key.ToLower()];
        }


        /// <inheritdoc/>
        public Type GetAliasValue(string contentTypeAlias, string propertyAlias)
        {
            return aliasPropertyMap[(contentTypeAlias + propertyAlias).ToLower()].GetType();
        }
    }
}
