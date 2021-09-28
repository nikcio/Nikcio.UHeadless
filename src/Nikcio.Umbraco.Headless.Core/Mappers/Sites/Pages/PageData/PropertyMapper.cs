using Nikcio.Umbraco.Headless.Core.Mappers.Bases;
using Nikcio.Umbraco.Headless.Core.Models.SiteModels.PageModels.PropertyModels;
using System.Collections.Generic;

namespace Nikcio.Umbraco.Headless.Core.Mappers.Sites.Pages.PageData
{
    public class PropertyMapper : BaseMapper, IPropertyMapper
    {
        private readonly Dictionary<string, string> editorPropertyMap = new();
        private readonly Dictionary<string, string> aliasPropertyMap = new();

        /// <inheritdoc/>
        public void AddEditorMapping<TType>(string editorName) where TType : class, IPropertyModelBase
        {
            AddMapping<TType>(editorName, editorPropertyMap);
        }

        /// <inheritdoc/>
        public void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : class, IPropertyModelBase
        {
            AddMapping<TType>(contentTypeAlias + propertyTypeAlias, aliasPropertyMap);
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
        public string GetEditorValue(string key)
        {
            return editorPropertyMap[key.ToLower()];
        }


        /// <inheritdoc/>
        public string GetAliasValue(string contentTypeAlias, string propertyAlias)
        {
            return aliasPropertyMap[(contentTypeAlias + propertyAlias).ToLower()];
        }
    }
}
