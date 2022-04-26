using System.Collections.Generic;
using HotChocolate;
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Models;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MemberPicker.Models {
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
        where TMember : MemberPickerItem<TProperty>
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
        protected virtual void AddMemberPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, CreatePropertyValue createPropertyValue, IPublishedContent member) {
            var memberItem = dependencyReflectorFactory.GetReflectedType<TMember>(typeof(TMember), new object[] { new CreateMemberPickerItem<TProperty>(createPropertyValue, member) });
            if (memberItem != null) {
                Members.Add(memberItem);
            }
        }
    }
}
