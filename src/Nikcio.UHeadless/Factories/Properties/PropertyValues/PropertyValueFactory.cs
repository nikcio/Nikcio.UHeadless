using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Mappers.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using System;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Factories.Properties.PropertyValues
{
    public class PropertyValueFactory : IPropertyValueFactory
    {
        private readonly IPropertyMap propertyMap;

        public PropertyValueFactory(IPropertyMap propertyMapper)
        {
            propertyMap = propertyMapper;
            AddPropertyMapDefaults();
        }
        private void AddPropertyMapDefaults()
        {
            if (!propertyMap.ContainsEditor("Default"))
            {
                propertyMap.AddEditorMapping<PropertyValueBasicGraphType>("Default");
            }
            if (!propertyMap.ContainsEditor(Constants.PropertyEditors.Aliases.BlockList))
            {
                propertyMap.AddEditorMapping<PropertyValueBlocklistModelGraphType>(Constants.PropertyEditors.Aliases.BlockList);
            }
        }

        public PropertyValueBaseGraphType GetPropertyValue(CreatePropertyValue createPropertyValue)
        {
            string propertyTypeAssemblyQualifiedName;
            if (createPropertyValue.Property.PropertyType.EditorAlias == Constants.PropertyEditors.Aliases.NestedContent)
            {
                return null;
            }

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
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue("Default");
            }
            return (PropertyValueBaseGraphType)Activator.CreateInstance(Type.GetType(propertyTypeAssemblyQualifiedName), new object[] { createPropertyValue });
        }
    }
}
