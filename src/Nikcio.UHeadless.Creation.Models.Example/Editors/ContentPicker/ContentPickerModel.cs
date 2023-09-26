using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.ContentPicker.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Extensions;

namespace Nikcio.UHeadless.Creation.Models.Example.Editors.ContentPicker;

/// <summary>
/// Represents a content picker value
/// </summary>
public class ContentPickerModel : PropertyValue
{
    /// <summary>
    /// Gets the list of content
    /// </summary>
    public virtual List<ContentPickerItemModel> ContentList { get; set; } = new();

    /// <inheritdoc/>
    public ContentPickerModel(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory, IVariationContextAccessor variationContextAccessor) : base(createPropertyValue)
    {
        var objectValue = createPropertyValue.Property.Value(createPropertyValue.PublishedValueFallback, createPropertyValue.Culture, createPropertyValue.Segment, createPropertyValue.Fallback);
        if (objectValue is IPublishedContent content)
        {
            AddContentPickerItem(dependencyReflectorFactory, content, variationContextAccessor, createPropertyValue.Culture);
        } else if (objectValue is IEnumerable<IPublishedContent> contentItems)
        {
            foreach (var contentItem in contentItems)
            {
                AddContentPickerItem(dependencyReflectorFactory, contentItem, variationContextAccessor, createPropertyValue.Culture);
            }
        }
    }

    /// <summary>
    /// Adds a content picker item to the content list
    /// </summary>
    /// <param name="dependencyReflectorFactory"></param>
    /// <param name="content"></param>
    /// <param name="variationContextAccessor"></param>
    /// <param name="culture"></param>
    protected void AddContentPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedContent content, IVariationContextAccessor variationContextAccessor, string? culture)
    {
        var contentPickerItem = dependencyReflectorFactory.GetReflectedType<ContentPickerItemModel>(typeof(ContentPickerItemModel), new object[] { new CreateContentPickerItem(content, variationContextAccessor, culture) });
        if (contentPickerItem != null)
        {
            ContentList.Add(contentPickerItem);
        }
    }
}
