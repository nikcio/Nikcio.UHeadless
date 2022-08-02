﻿using Nikcio.UHeadless.Base.Basics.EditorsValues.Labels.Models;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.BlockList.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.ContentPicker.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.DateTimePicker.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.Fallback.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.MediaPicker.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.MultiUrlPicker.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.NestedContent.Models;
using Nikcio.UHeadless.Basics.Properties.EditorsValues.RichTextEditor.Models;
using Nikcio.UHeadless.Core.Constants;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Basics.Properties.Maps.Extensions {
    /// <summary>
    /// Extensions
    /// </summary>
    public static class PropertyMapExtensions {

        /// <summary>
        /// Adds the default mappings to the property map
        /// </summary>
        public static void AddPropertyMapDefaults(this IPropertyMap propertyMap) {
            propertyMap.AddEditorMapping<BasicPropertyValue>(PropertyConstants.DefaultKey);
            propertyMap.AddEditorMapping<BasicBlockListModel>(Constants.PropertyEditors.Aliases.BlockList);
            propertyMap.AddEditorMapping<BasicNestedContent>(Constants.PropertyEditors.Aliases.NestedContent);
            propertyMap.AddEditorMapping<BasicRichText>(Constants.PropertyEditors.Aliases.TinyMce);
            propertyMap.AddEditorMapping<BasicMemberPicker>(Constants.PropertyEditors.Aliases.MemberPicker);
            propertyMap.AddEditorMapping<BasicContentPicker>(Constants.PropertyEditors.Aliases.ContentPicker);
            propertyMap.AddEditorMapping<BasicMultiUrlPicker>(Constants.PropertyEditors.Aliases.MultiUrlPicker);
            propertyMap.AddEditorMapping<BasicContentPicker>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            propertyMap.AddEditorMapping<BasicContentPicker>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
            propertyMap.AddEditorMapping<BasicMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker);
            propertyMap.AddEditorMapping<BasicMediaPicker>(Constants.PropertyEditors.Aliases.MediaPicker3);
            propertyMap.AddEditorMapping<BasicMediaPicker>(Constants.PropertyEditors.Aliases.MultipleMediaPicker);
            propertyMap.AddEditorMapping<BasicDateTimePicker>(Constants.PropertyEditors.Aliases.DateTime);
            propertyMap.AddEditorMapping<BasicLabel>(Constants.PropertyEditors.Aliases.Label);
        }
    }
}
