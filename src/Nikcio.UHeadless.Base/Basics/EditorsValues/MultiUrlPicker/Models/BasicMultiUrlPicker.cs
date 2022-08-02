﻿using HotChocolate;
using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MultiUrlPicker.Commands;
using Nikcio.UHeadless.Base.Properties.EditorsValues.MultiUrlPicker.Models;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Reflection.Factories;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.Basics.Properties.EditorsValues.MultiUrlPicker.Models {
    /// <summary>
    /// Represents a multi url picker
    /// </summary>
    [GraphQLDescription("Represents a multi url picker.")]
    public class BasicMultiUrlPicker : BasicMultiUrlPicker<BasicMultiUrlPickerItem> {
        /// <inheritdoc/>
        public BasicMultiUrlPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue, dependencyReflectorFactory) {
        }
    }

    /// <summary>
    /// Represents a multi url picker
    /// </summary>
    [GraphQLDescription("Represents a multi url picker.")]
    public class BasicMultiUrlPicker<TLink> : PropertyValue
        where TLink : MultiUrlPickerItem {
        /// <summary>
        /// Gets the links
        /// </summary>
        [GraphQLDescription("Gets the links.")]
        public virtual List<TLink> Links { get; set; } = new();

        /// <inheritdoc/>
        public BasicMultiUrlPicker(CreatePropertyValue createPropertyValue, IDependencyReflectorFactory dependencyReflectorFactory) : base(createPropertyValue) {
            var value = createPropertyValue.GetPropertyValue();
            if (value is IEnumerable<Link> links) {
                if (links.Any()) {
                    foreach (var link in links) {
                        AddLinkPickerItem(dependencyReflectorFactory, link);
                    }
                }
            } else if (value is Link link) {
                AddLinkPickerItem(dependencyReflectorFactory, link);
            }
        }

        /// <summary>
        /// Adds a member item to the member picker
        /// </summary>
        /// <param name="dependencyReflectorFactory"></param>
        /// <param name="link"></param>
        protected void AddLinkPickerItem(IDependencyReflectorFactory dependencyReflectorFactory, Link link) {
            var linkItem = dependencyReflectorFactory.GetReflectedType<TLink>(typeof(TLink), new object[] { new CreateMultiUrlPickerItem(link) });
            if (linkItem != null) {
                Links.Add(linkItem);
            }
        }
    }
}
