using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MemberPicker.Models {
    /// <summary>
    /// Represents a member picker
    /// </summary>
    [GraphQLDescription("Represents a member picker.")]
    public class BasicMemberPicker : BasicMemberPicker<BasicMemberPickerItem> {
        /// <inheritdoc/>
        public BasicMemberPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a member picker
    /// </summary>
    /// <typeparam name="TMember"></typeparam>
    [GraphQLDescription("Represents a member picker.")]
    public class BasicMemberPicker<TMember> : PropertyValue
        where TMember : MemberPickerItem {
        /// <summary>
        /// Gets the members
        /// </summary>
        [GraphQLDescription("Gets the members.")]
        public virtual List<TMember> Members { get; set; } = new();

        /// <inheritdoc/>
        public BasicMemberPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var objectValue = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (objectValue is IPublishedContent memberItem) {
                AddMemberPickerItem(dependencyReflectorFactory, createPropertyValue, memberItem);
            } else if (objectValue is not null) {
                var members = (IEnumerable<IPublishedContent>) objectValue;
                if (members != null) {
                    foreach (var member in members) {
                        AddMemberPickerItem(dependencyReflectorFactory, createPropertyValue, member);
                    }
                }
            }

        }

        /// <summary>
        /// Adds a member item to the member picker
        /// </summary>
        /// <param name="dependencyReflectorFactory"></param>
        /// <param name="createPropertyValue"></param>
        /// <param name="member"></param>
        protected void AddMemberPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, CreatePropertyValue createPropertyValue, IPublishedContent member) {
            var memberItem = dependencyReflectorFactory.GetReflectedType<TMember>(typeof(TMember), new object[] { new CreateMemberPickerItem(createPropertyValue, member) });
            if (memberItem != null) {
                Members.Add(memberItem);
            }
        }
    }
}
