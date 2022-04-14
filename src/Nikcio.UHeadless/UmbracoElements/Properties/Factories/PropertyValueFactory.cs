using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoElements.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoElements.Properties.EditorsValues.Fallback.Commands;
using Nikcio.UHeadless.UmbracoElements.Properties.Maps;
using Nikcio.UHeadless.UmbracoElements.Properties.UConstants;
using System;

namespace Nikcio.UHeadless.UmbracoElements.Properties.Factories
{
    /// <inheritdoc/>
    public class PropertyValueFactory : IPropertyValueFactory
    {
        /// <summary>
        /// A map of what class to use for a property
        /// </summary>
        protected readonly IPropertyMap propertyMap;

        /// <summary>
        /// A factory that can create object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public PropertyValueFactory(IPropertyMap propertyMapper, IDependencyReflectorFactory dependencyReflectorFactory)
        {
            propertyMap = propertyMapper;
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual PropertyValue? GetPropertyValue(CreatePropertyValue createPropertyValue)
        {
            string propertyTypeAssemblyQualifiedName;
            if (propertyMap.ContainsAlias(createPropertyValue.Property.PropertyType.ContentType.Alias, createPropertyValue.Property.PropertyType.Alias))
            {
                propertyTypeAssemblyQualifiedName = propertyMap.GetAliasValue(createPropertyValue.Property.PropertyType.ContentType.Alias, createPropertyValue.Property.PropertyType.Alias);

            }
            else if (propertyMap.ContainsEditor(createPropertyValue.Property.PropertyType.EditorAlias))
            {
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(createPropertyValue.Property.PropertyType.EditorAlias);
            }
            else
            {
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(PropertyConstants.DefaultKey);
            }
            var type = Type.GetType(propertyTypeAssemblyQualifiedName);
            if (type == null)
            {
                return null;
            }

            return dependencyReflectorFactory.GetReflectedType<PropertyValue>(type, new object[] { createPropertyValue });
        }
    }
}
