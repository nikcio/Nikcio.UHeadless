using Nikcio.UHeadless.Base.Properties.Models;

namespace Nikcio.UHeadless.Base.Properties.Maps;

/// <summary>
/// A map of all property types
/// </summary>
public interface IPropertyMap
{
    /// <summary>
    /// Adds a mapping of a type to a content type alias combined with a property type alias.
    /// </summary>
    /// <typeparam name="TType">The type that should be used for this property</typeparam>
    /// <param name="contentTypeAlias"></param>
    /// <param name="propertyTypeAlias"></param>
    /// <example>
    /// ContentTypeAlias: MyDocType
    /// PropertyTypeAlias: MyProperty
    /// </example>
    /// <remarks>This takes precedence over editor mappings</remarks>
    void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : PropertyValue;

    /// <summary>
    /// Adds a mapping of a type to a editor alias.
    /// </summary>
    /// <typeparam name="TType">The type that should be used for this property</typeparam>
    /// <param name="editorName"></param>
    void AddEditorMapping<TType>(string editorName) where TType : PropertyValue;

    /// <summary>
    /// Checks if a alias is already in the map
    /// </summary>
    /// <param name="contentTypeAlias"></param>
    /// <param name="propertyTypeAlias"></param>
    /// <returns></returns>
    bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias);

    /// <summary>
    /// Checks if a editor alias is already in the map
    /// </summary>
    /// <param name="editorName"></param>
    /// <returns></returns>
    bool ContainsEditor(string editorName);

    /// <summary>
    /// Gets a alias value
    /// </summary>
    /// <param name="contentTypeAlias"></param>
    /// <param name="propertyAlias"></param>
    /// <returns>The types AssemblyQualifiedName</returns>
    string GetAliasValue(string contentTypeAlias, string propertyAlias);

    /// <summary>
    /// Gets all types used in the property map
    /// </summary>
    /// <returns></returns>
    IEnumerable<Type> GetAllTypes();

    /// <summary>
    /// Get a editor value
    /// </summary>
    /// <param name="key"></param>
    /// <returns>he types AssemblyQualifiedName</returns>
    string GetEditorValue(string key);
}