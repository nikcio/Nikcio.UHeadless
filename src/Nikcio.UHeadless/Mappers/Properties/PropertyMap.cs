using Nikcio.UHeadless.Mappers.Bases;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System.Collections.Generic;

namespace Nikcio.UHeadless.Mappers.Properties
{
    public class PropertyMap : BaseMap, IPropertyMap
    {
        private readonly Dictionary<string, string> editorPropertyMap = new();
        private readonly Dictionary<string, string> aliasPropertyMap = new();

        /// <inheritdoc/>
        public void AddEditorMapping<TType>(string editorName) where TType : PropertyValueBaseGraphType
        {
            AddMapping<TType>(editorName, editorPropertyMap);
        }

        /// <inheritdoc/>
        public void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : PropertyValueBaseGraphType
        {
            AddMapping<TType>(contentTypeAlias + propertyTypeAlias, aliasPropertyMap);
        }

        /// <inheritdoc/>
        public bool ContainsEditor(string editorName)
        {
            return editorPropertyMap.ContainsKey(editorName.ToLowerInvariant());
        }

        /// <inheritdoc/>
        public bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias)
        {
            return aliasPropertyMap.ContainsKey((contentTypeAlias + propertyTypeAlias).ToLowerInvariant());
        }

        /// <inheritdoc/>
        public string GetEditorValue(string key)
        {
            return editorPropertyMap[key.ToLowerInvariant()];
        }


        /// <inheritdoc/>
        public string GetAliasValue(string contentTypeAlias, string propertyAlias)
        {
            return aliasPropertyMap[(contentTypeAlias + propertyAlias).ToLowerInvariant()];
        }
    }
}
