using Nikcio.UHeadless.Maps.Bases;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.ContentPicker;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.MultiUrlPicker.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.NestedContent.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.RichTextEditor.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.UConstants;
using System.Collections.Generic;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Maps
{
    public class PropertyMap : BaseMap, IPropertyMap
    {
        private readonly Dictionary<string, string> editorPropertyMap = new();
        private readonly Dictionary<string, string> aliasPropertyMap = new();

        public void AddPropertyMapDefaults()
        {
            if (!ContainsEditor(UConstants.Constants.PropertyConstants.DefaultKey))
            {
                AddEditorMapping<PropertyValueBasicGraphType>(UConstants.Constants.PropertyConstants.DefaultKey);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.BlockList))
            {
                AddEditorMapping<BlockListModelGraphType<BlockListItemGraphType>>(Constants.PropertyEditors.Aliases.BlockList);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.NestedContent))
            {
                AddEditorMapping<NestedContentGraphType<NestedContentElementGraphType>>(Constants.PropertyEditors.Aliases.NestedContent);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.TinyMce))
            {
                AddEditorMapping<RteGraphType>(Constants.PropertyEditors.Aliases.TinyMce);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.MemberPicker))
            {
                AddEditorMapping<MemberPickerGraphType>(Constants.PropertyEditors.Aliases.MemberPicker);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.ContentPicker))
            {
                AddEditorMapping<ContentPickerGraphType>(Constants.PropertyEditors.Aliases.ContentPicker);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.MultiUrlPicker))
            {
                AddEditorMapping<MultiUrlPickerGraphType>(Constants.PropertyEditors.Aliases.MultiUrlPicker);
            }
            if (!ContainsEditor(Constants.PropertyEditors.Aliases.MultiNodeTreePicker))
            {
                AddEditorMapping<ContentPickerGraphType>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            }
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
