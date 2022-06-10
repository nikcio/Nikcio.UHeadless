using HotChocolate;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Nikcio.UHeadless.Properties.Bases.Models;
using Nikcio.UHeadless.Properties.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.MemberPicker.Commands;
using Nikcio.UHeadless.Properties.EditorsValues.MemberPicker.Models;
using Nikcio.UHeadless.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MemberPicker.Models {
    /// <summary>
    /// Represents a member picker
    /// </summary>
    [GraphQLDescription("Represents a member picker.")]
    public class BasicMemberPicker : BasicMemberPicker<BasicProperty> {
        /// <inheritdoc/>
        public BasicMemberPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a member picker
    /// </summary>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a member picker.")]
    public class BasicMemberPicker<TProperty> : BasicMemberPicker<BasicMemberPickerItem<TProperty>, TProperty>
        where TProperty : IProperty {
        /// <inheritdoc/>
        public BasicMemberPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a member picker
    /// </summary>
    /// <typeparam name="TMember"></typeparam>
    /// <typeparam name="TProperty"></typeparam>
    [GraphQLDescription("Represents a member picker.")]
    public class BasicMemberPicker<TMember, TProperty> : PropertyValue
        where TMember : MemberPickerItem
        where TProperty : IProperty {
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
