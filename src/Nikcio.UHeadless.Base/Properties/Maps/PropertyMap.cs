using Nikcio.UHeadless.Base.Properties.Bases.Models;
using Nikcio.UHeadless.Core.Maps;

namespace Nikcio.UHeadless.Base.Properties.Maps {
    /// <inheritdoc/>
    public class PropertyMap : DictionaryMap, IPropertyMap {
        /// <summary>
        /// Editor mappings
        /// </summary>
        protected readonly Dictionary<string, string> editorPropertyMap = new();

        /// <summary>
        /// Alias mappings
        /// </summary>
        protected readonly Dictionary<string, string> aliasPropertyMap = new();

        /// <inheritdoc/>
        public virtual void AddEditorMapping<TType>(string editorName) where TType : PropertyValue {
            AddMapping<TType>(editorName, editorPropertyMap);
        }

        /// <inheritdoc/>
        public virtual void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : PropertyValue {
            AddMapping<TType>(contentTypeAlias + propertyTypeAlias, aliasPropertyMap);
        }

        /// <inheritdoc/>
        public virtual bool ContainsEditor(string editorName) {
            return editorPropertyMap.ContainsKey(editorName.ToLowerInvariant());
        }

        /// <inheritdoc/>
        public virtual bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias) {
            return aliasPropertyMap.ContainsKey((contentTypeAlias + propertyTypeAlias).ToLowerInvariant());
        }

        /// <inheritdoc/>
        public virtual string GetEditorValue(string key) {
            return editorPropertyMap[key.ToLowerInvariant()];
        }


        /// <inheritdoc/>
        public virtual string GetAliasValue(string contentTypeAlias, string propertyAlias) {
            return aliasPropertyMap[(contentTypeAlias + propertyAlias).ToLowerInvariant()];
        }
    }
}
