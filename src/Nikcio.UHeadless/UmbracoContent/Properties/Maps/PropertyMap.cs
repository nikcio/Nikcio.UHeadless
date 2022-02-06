using Nikcio.UHeadless.Maps.Bases;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.ContentPicker;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MediaPicker.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MultiUrlPicker.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.RichTextEditor.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.UConstants;
using System.Collections.Generic;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Maps
{
    /// <inheritdoc/>
    public class PropertyMap : BaseMap, IPropertyMap
    {
        private readonly Dictionary<string, string> editorPropertyMap = new();
        private readonly Dictionary<string, string> aliasPropertyMap = new();

        /// <inheritdoc/>
        public void AddPropertyMapDefaults()
        {
            AddEditorMapping<PropertyValueBasicGraphType>(PropertyConstants.DefaultKey);
            AddEditorMapping<BlockListModelGraphType<BlockListItemGraphType>>(Constants.PropertyEditors.Aliases.BlockList);
            AddEditorMapping<NestedContentGraphType<NestedContentElementGraphType>>(Constants.PropertyEditors.Aliases.NestedContent);
            AddEditorMapping<RteGraphType>(Constants.PropertyEditors.Aliases.TinyMce);
            AddEditorMapping<MemberPickerGraphType>(Constants.PropertyEditors.Aliases.MemberPicker);
            AddEditorMapping<ContentPickerGraphType>(Constants.PropertyEditors.Aliases.ContentPicker);
            AddEditorMapping<MultiUrlPickerGraphType>(Constants.PropertyEditors.Aliases.MultiUrlPicker);
            AddEditorMapping<ContentPickerGraphType>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            AddEditorMapping<ContentPickerGraphType>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            AddEditorMapping<MediaPickerGraphType>(Constants.PropertyEditors.Aliases.MediaPicker);
            AddEditorMapping<MediaPickerGraphType>(Constants.PropertyEditors.Aliases.MediaPicker3);
            AddEditorMapping<MediaPickerGraphType>(Constants.PropertyEditors.Aliases.MultipleMediaPicker);
        }

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
