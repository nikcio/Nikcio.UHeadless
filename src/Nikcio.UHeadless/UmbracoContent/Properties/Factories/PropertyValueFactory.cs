using Nikcio.UHeadless.Reflection.Factories;
using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;
using Nikcio.UHeadless.UmbracoContent.Properties.EditorsValues.Default.Commands;
using Nikcio.UHeadless.UmbracoContent.Properties.Maps;
using Nikcio.UHeadless.UmbracoContent.Properties.UConstants;
using System;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Factories
{
    public class PropertyValueFactory : IPropertyValueFactory
    {
        private readonly IPropertyMap propertyMap;
        private readonly IDependencyReflectorFactory dependencyReflectorFactory;

        public PropertyValueFactory(IPropertyMap propertyMapper, IDependencyReflectorFactory dependencyReflectorFactory)
        {
            propertyMap = propertyMapper;
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        public PropertyValueBaseGraphType GetPropertyValue(CreatePropertyValue createPropertyValue)
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
            return dependencyReflectorFactory.GetReflectedType<PropertyValueBaseGraphType>(type, new object[1] { createPropertyValue });
        }
    }
}
