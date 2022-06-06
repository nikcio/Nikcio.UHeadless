using System.Collections.Generic;
using Nikcio.UHeadless.Maps.Bases;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.ContentPicker;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.DatePicker.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MediaPicker.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MultiUrlPicker.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.NestedContent.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.RichTextEditor.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.UConstants;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Maps {
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
        public virtual void AddPropertyMapDefaults() {
            AddEditorMapping<BasicPropertyValue>(PropertyConstants.DefaultKey);
            AddEditorMapping<BasicBlockListModel<BasicBlockListItem<BasicProperty>>>(Constants.PropertyEditors.Aliases.BlockList);
            AddEditorMapping<BasicNestedContent<BasicNestedContentElement<BasicProperty>>>(Constants.PropertyEditors.Aliases.NestedContent);
            AddEditorMapping<BasicRichText>(Constants.PropertyEditors.Aliases.TinyMce);
            AddEditorMapping<BasicMemberPicker<BasicProperty>>(Constants.PropertyEditors.Aliases.MemberPicker);
            AddEditorMapping<BasicContentPicker>(Constants.PropertyEditors.Aliases.ContentPicker);
            AddEditorMapping<BasicMultiUrlPicker>(Constants.PropertyEditors.Aliases.MultiUrlPicker);
            AddEditorMapping<BasicContentPicker>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            AddEditorMapping<BasicContentPicker>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            AddEditorMapping<BasicMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker);
            AddEditorMapping<BasicMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker3);
            AddEditorMapping<BasicMediaPicker>(Constants.PropertyEditors.Aliases.MultipleMediaPicker);
            AddEditorMapping<BasicDateTimePicker>(Constants.PropertyEditors.Aliases.DateTime);
        }

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
