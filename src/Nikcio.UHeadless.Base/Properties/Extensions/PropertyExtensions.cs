using Microsoft.Extensions.DependencyInjection;
using Nikcio.UHeadless.Base.Properties.Commands;
using Umbraco.Cms.Core.Models.PublishedContent;

namespace Nikcio.UHeadless.Base.Properties.Extensions {
    /// <summary>
    /// Property extensions
    /// </summary>
    public static class PropertyExtensions {
        /// <summary>
        /// Adds all the property services
        /// </summary>
        /// <param name="services"></param>
        /// <param name="propertyServicesOptions"></param>
        /// <returns></returns>
        public static IServiceCollection AddPropertyServices(this IServiceCollection services, PropertyServicesOptions propertyServicesOptions) {
            services
                .AddPropertyFactories()
                .AddPropertyMaps(propertyServicesOptions.PropertyMapOptions)
                .AddPropertyRepositories();

            return services;
        }

        /// <summary>
        /// Gets a property value
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        public static object? GetPropertyValue(this CreatePropertyValue createPropertyValue) {
            if (createPropertyValue is CreatePublishedPropertyValue createPublishedPropertyValue) {
                return createPublishedPropertyValue.Property.GetValue(createPropertyValue.Culture);
            } else if (createPropertyValue is CreateRawPropertyValue createRawPropertyValue) {
                return createRawPropertyValue.Property.GetValue(createPropertyValue.Culture);
            }
            return default;
        }

        /// <summary>
        /// Gets a content type alias
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        /// <remarks>
        /// A raw property will always return the content base content type alias instead of the property type content type alias due to limitations in content type access.
        /// </remarks>
        public static string? GetContentTypeAlias(this CreatePropertyValue createPropertyValue) {
            if (createPropertyValue is CreatePublishedPropertyValue createPublishedPropertyValue) {
                return createPublishedPropertyValue.Property.PropertyType.ContentType?.Alias;
            } else if (createPropertyValue is CreateRawPropertyValue createRawPropertyValue) {
                return createRawPropertyValue.ContentBase.ContentType.Alias;
            }
            return null;
        }

        /// <summary>
        /// Gets a property editor alias
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        public static string? GetEditorAlias(this CreatePropertyValue createPropertyValue) {
            if (createPropertyValue is CreatePublishedPropertyValue createPublishedPropertyValue) {
                return createPublishedPropertyValue.Property.PropertyType.EditorAlias;
            } else if (createPropertyValue is CreateRawPropertyValue createRawPropertyValue) {
                return createRawPropertyValue.Property.PropertyType.PropertyEditorAlias;
            }
            return null;
        }

        /// <summary>
        /// Gets a property alias
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        public static string? GetAlias(this CreatePropertyValue createPropertyValue) {
            if (createPropertyValue is CreatePublishedPropertyValue createPublishedPropertyValue) {
                return createPublishedPropertyValue.Property.PropertyType.Alias;
            } else if (createPropertyValue is CreateRawPropertyValue createRawPropertyValue) {
                return createRawPropertyValue.Property.PropertyType.Alias;
            }
            return null;
        }

        /// <summary>
        /// Gets the content node
        /// </summary>
        /// <param name="createPropertyValue"></param>
        /// <returns></returns>
        public static IPublishedContent? GetContent(this CreatePropertyValue createPropertyValue) {
            if (createPropertyValue is CreatePublishedPropertyValue createPublishedPropertyValue) {
                return createPublishedPropertyValue.Content;
            } else if (createPropertyValue is CreateRawPropertyValue createRawPropertyValue) {
                throw new NotImplementedException(); // TODO
            }
            return null;
        }
    }
}
