using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Extensions;
using Nikcio.UHeadless.Base.Properties.Maps;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Constants;
using Nikcio.UHeadless.Core.Reflection.Factories;

namespace Nikcio.UHeadless.Base.Properties.Factories {
    /// <inheritdoc/>
    public class PropertyValueFactory : IPropertyValueFactory {
        /// <summary>
        /// A map of what class to use for a property
        /// </summary>
        protected readonly IPropertyMap propertyMap;

        /// <summary>
        /// A factory that can create object with DI
        /// </summary>
        protected readonly IDependencyReflectorFactory dependencyReflectorFactory;

        /// <inheritdoc/>
        public PropertyValueFactory(IPropertyMap propertyMapper, IDependencyReflectorFactory dependencyReflectorFactory) {
            propertyMap = propertyMapper;
            this.dependencyReflectorFactory = dependencyReflectorFactory;
        }

        /// <inheritdoc/>
        public virtual PropertyValue? GetPropertyValue(CreatePropertyValue createPropertyValue) {
            string propertyTypeAssemblyQualifiedName;
            if (createPropertyValue.GetContentTypeAlias() == null) {
                return default;
            }
            if (propertyMap.ContainsAlias(createPropertyValue.GetContentTypeAlias() ?? "Unknown", createPropertyValue.GetAlias() ?? "Unknown")) {
                propertyTypeAssemblyQualifiedName = propertyMap.GetAliasValue(createPropertyValue.GetContentTypeAlias() ?? "Unknown", createPropertyValue.GetAlias() ?? "Unknown");

            } else if (propertyMap.ContainsEditor(createPropertyValue.GetEditorAlias() ?? "Unknown")) {
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(createPropertyValue.GetEditorAlias() ?? "Unknown");
            } else {
                propertyTypeAssemblyQualifiedName = propertyMap.GetEditorValue(PropertyConstants.DefaultKey);
            }
            var type = Type.GetType(propertyTypeAssemblyQualifiedName);
            if (type == null) {
                return null;
            }

            return dependencyReflectorFactory.GetReflectedType<PropertyValue>(type, new object[] { createPropertyValue });
        }
    }
}
