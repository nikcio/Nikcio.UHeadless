using HotChocolate;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.ContentPicker.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.ContentPicker.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.ContentPicker.Models {
    /// <summary>
    /// Represents a content picker value
    /// </summary>
    [GraphQLDescription("Represents a content picker value.")]
    public class BasicContentPicker : BasicContentPicker<BasicContentPickerItem> {
        /// <inheritdoc/>
        public BasicContentPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a content picker value
    /// </summary>
    [GraphQLDescription("Represents a content picker value.")]
    public class BasicContentPicker<TContentPickerItem> : PropertyValue
        where TContentPickerItem : ContentPickerItem {
        /// <summary>
        /// Gets the list of content
        /// </summary>
        [GraphQLDescription("Gets the list of content.")]
        public virtual List<TContentPickerItem> ContentList { get; set; } = new();

        /// <inheritdoc/>
        public BasicContentPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent content) {
                AddContentPickerItem(dependencyReflectorFactory, content);
            } else if (objectValue != null) {
                var contentList = (IEnumerable<IPublishedContent>) objectValue;
                if (contentList != null) {
                    foreach (var contentItem in contentList) {
                        AddContentPickerItem(dependencyReflectorFactory, contentItem);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a content picker item to the content list
        /// </summary>
        /// <param name="dependencyReflectorFactory"></param>
        /// <param name="content"></param>
        protected void AddContentPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, IPublishedContent content) {
            var contentPickerItem = dependencyReflectorFactory.GetReflectedType<TContentPickerItem>(typeof(TContentPickerItem), new object[] { new CreateContentPickerItem(content) });
            if (contentPickerItem != null) {
                ContentList.Add(contentPickerItem);
            }
        }
    }
}
