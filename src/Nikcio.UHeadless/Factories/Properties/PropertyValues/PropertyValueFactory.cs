﻿using Nikcio.UHeadless.Commands.Properties;
using Nikcio.UHeadless.Factories.Reflection;
using Nikcio.UHeadless.Mappers.Properties;
using Nikcio.UHeadless.Models.Dtos.Propreties.PropertyValues;
using Nikcio.UHeadless.Models.Properties.BlockList;
using Nikcio.UHeadless.Models.Properties.NestedContent;
using System;
using Umbraco.Cms.Core;

namespace Nikcio.UHeadless.Factories.Properties.PropertyValues
{
    public class PropertyValueFactory : IPropertyValueFactory
    {
        private readonly IPropertyMap propertyMap;
        private readonly IDependencyReflectorFactory dependencyReflectorFactory;

        public PropertyValueFactory(IPropertyMap propertyMapper, IDependencyReflectorFactory dependencyReflectorFactory)
        {
            propertyMap = propertyMapper;
            this.dependencyReflectorFactory = dependencyReflectorFactory;
            AddPropertyMapDefaults();
        }
        private void AddPropertyMapDefaults()
        {
            if (!propertyMap.ContainsEditor(UHeadlessConstants.Constants.PropertyConstants.DefaultKey))
            {
                propertyMap.AddEditorMapping<PropertyValueBasicGraphType>(UHeadlessConstants.Constants.PropertyConstants.DefaultKey);
            }
            if (!propertyMap.ContainsEditor(Constants.PropertyEditors.Aliases.BlockList))
            {
                propertyMap.AddEditorMapping<BlockListModelGraphType>(Constants.PropertyEditors.Aliases.BlockList);
            }
            if (!propertyMap.ContainsEditor(Constants.PropertyEditors.Aliases.NestedContent))
            {
                propertyMap.AddEditorMapping<NestedContentGraphType>(Constants.PropertyEditors.Aliases.NestedContent);
            }
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
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(UHeadlessConstants.Constants.PropertyConstants.DefaultKey);
            }
            var type = Type.GetType(propertyTypeAssemblyQualifiedName);
            return dependencyReflectorFactory.GetReflectedType<PropertyValueBaseGraphType>(type, new object[1] { createPropertyValue });
        }
    }
}
