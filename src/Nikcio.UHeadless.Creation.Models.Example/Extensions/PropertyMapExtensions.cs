using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Core.Constants;
using Nikcio.UHeadless.Creation.Models.Example.Editors.BlockGrid;
using Nikcio.UHeadless.Creation.Models.Example.Editors.BlockList;
using Nikcio.UHeadless.Creation.Models.Example.Editors.ContentPicker;
using Nikcio.UHeadless.Creation.Models.Example.Editors.DateTimePicker;
using Nikcio.UHeadless.Creation.Models.Example.Editors.Fallback;
using Nikcio.UHeadless.Creation.Models.Example.Editors.Labels;
using Nikcio.UHeadless.Creation.Models.Example.Editors.MediaPicker;
using Nikcio.UHeadless.Creation.Models.Example.Editors.MemberPicker;
using Nikcio.UHeadless.Creation.Models.Example.Editors.MultiUrlPicker;
using Nikcio.UHeadless.Creation.Models.Example.Editors.NestedContent;
using Nikcio.UHeadless.Creation.Models.Example.Editors.RichTextEditor;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Creation.Models.Example.Extensions;

/// <summary>
/// Extensions
/// </summary>
public static class PropertyMapExtensions
{
    /// <summary>
    /// Adds the default mappings to the property map
    /// </summary>
    public static void AddPropertyMapDefaults(this IPropertyMap propertyMap)
    {
        propertyMap.AddEditorMapping<FallbackPropertyModel>(PropertyConstants.DefaultKey);
        propertyMap.AddEditorMapping<BlockListModel>(Constants.PropertyEditors.Aliases.BlockList);
        propertyMap.AddEditorMapping<BlockGridModel>(Constants.PropertyEditors.Aliases.BlockGrid);
        propertyMap.AddEditorMapping<NestedContentModel>(Constants.PropertyEditors.Aliases.NestedContent);
        propertyMap.AddEditorMapping<RichTextModel>(Constants.PropertyEditors.Aliases.TinyMce);
        propertyMap.AddEditorMapping<RichTextModel>(Constants.PropertyEditors.Aliases.MarkdownEditor);
        propertyMap.AddEditorMapping<MemberPickerModel>(Constants.PropertyEditors.Aliases.MemberPicker);
        propertyMap.AddEditorMapping<ContentPickerModel>(Constants.PropertyEditors.Aliases.ContentPicker);
        propertyMap.AddEditorMapping<MultiUrlPickerModel>(Constants.PropertyEditors.Aliases.MultiUrlPicker);
        propertyMap.AddEditorMapping<ContentPickerModel>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
        propertyMap.AddEditorMapping<ContentPickerModel>(Constants.PropertyEditors.Aliases.MultiNodeTreePicker);
        propertyMap.AddEditorMapping<MediaPickerModel>(Constants.PropertyEditors.Aliases.MediaPicker);
        propertyMap.AddEditorMapping<MediaPickerModel>(Constants.PropertyEditors.Aliases.MediaPicker3);
        propertyMap.AddEditorMapping<MediaPickerModel>(Constants.PropertyEditors.Aliases.MultipleMediaPicker);
        propertyMap.AddEditorMapping<DateTimePickerModel>(Constants.PropertyEditors.Aliases.DateTime);
        propertyMap.AddEditorMapping<LabelModel>(Constants.PropertyEditors.Aliases.Label);
        propertyMap.AddEditorMapping<UnsupportedPropertyModel>(Constants.PropertyEditors.Aliases.Grid);
    }
}
