﻿using System.Collections.Generic;
using System.Linq;
using HotChocolate;
using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MultiUrlPicker.Commands;
using Umbraco.Cms.Core.Models;

namespace Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.MultiUrlPicker.Models {
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
            var value = createPropertyValue.Property.GetValue(createPropertyValue.Culture);
            if (value is IEnumerable<Link> links) {
                if(links != null && links.Any()) {
                    foreach (var link in links) {
                        AddLinkPickerItem(dependencyReflectorFactory, link);
                    }
                }
            }else if(value is Link link) {
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
