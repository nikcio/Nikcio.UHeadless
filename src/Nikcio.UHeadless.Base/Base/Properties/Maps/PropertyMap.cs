using Nikcio.UHeadless.Base.Properties.Commands;
using Nikcio.UHeadless.Base.Properties.Models;
using Nikcio.UHeadless.Core.Constants;
using Nikcio.UHeadless.Core.Maps;

namespace Nikcio.UHeadless.Base.Properties.Maps;

/// <inheritdoc/>
public class PropertyMap : DictionaryMap, IPropertyMap
{
    /// <summary>
    /// Editor mappings
    /// </summary>
    protected readonly Dictionary<string, string> editorPropertyMap = new();

    /// <summary>
    /// Alias mappings
    /// </summary>
    protected readonly Dictionary<string, string> aliasPropertyMap = new();

    /// <summary>
    /// A list of all the types used in the property mapping
    /// </summary>
    protected readonly HashSet<Type> types = new();

    /// <inheritdoc/>
    public virtual void AddEditorMapping<TType>(string editorName) where TType : PropertyValue
    {
        AddMapping<TType>(GetEditorMappingKey(editorName), editorPropertyMap);
        AddUsedType<TType>();
    }

    /// <inheritdoc/>
    public virtual void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : PropertyValue
    {
        AddMapping<TType>(GetAliasMappingKey(contentTypeAlias, propertyTypeAlias), aliasPropertyMap);
        AddUsedType<TType>();
    }

    /// <inheritdoc/>
    public virtual string GetEditorMappingKey(string editorName)
    {
        return editorName.ToLowerInvariant();
    }

    /// <inheritdoc/>
    public virtual string GetAliasMappingKey(string contentTypeAlias, string propertyTypeAlias)
    {
        return $"{contentTypeAlias}&&{propertyTypeAlias}".ToLowerInvariant();
    }

    /// <inheritdoc/>
    public virtual bool ContainsEditor(string editorName)
    {
        return editorPropertyMap.ContainsKey(GetEditorMappingKey(editorName));
    }

    /// <inheritdoc/>
    public virtual bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias)
    {
        return aliasPropertyMap.ContainsKey(GetAliasMappingKey(contentTypeAlias, propertyTypeAlias));
    }

    /// <inheritdoc/>
    public virtual string GetEditorValue(string editorName)
    {
        return editorPropertyMap[GetEditorMappingKey(editorName)];
    }

    /// <inheritdoc/>
    public virtual string GetAliasValue(string contentTypeAlias, string propertyTypeAlias)
    {
        return aliasPropertyMap[GetAliasMappingKey(contentTypeAlias, propertyTypeAlias)];
    }

    /// <inheritdoc/>
    public virtual IEnumerable<Type> GetAllTypes()
    {
        return types;
    }

    /// <inheritdoc/>
    public virtual string GetPropertyTypeAssemblyQualifiedName(string contentTypeAlias, string propertyTypeAlias, string editorAlias)
    {
        string propertyTypeAssemblyQualifiedName;
        if (ContainsAlias(contentTypeAlias, propertyTypeAlias))
        {
            propertyTypeAssemblyQualifiedName = GetAliasValue(contentTypeAlias, propertyTypeAlias);
        } else if (ContainsEditor(editorAlias))
        {
            propertyTypeAssemblyQualifiedName = GetEditorValue(editorAlias);
        } else
        {
            propertyTypeAssemblyQualifiedName = GetEditorValue(PropertyConstants.DefaultKey);
        }
        return propertyTypeAssemblyQualifiedName;
    }

    /// <summary>
    /// Adds a type to the types list if it's not already present
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    protected virtual void AddUsedType<TType>() where TType : PropertyValue
    {
        if (!types.Contains(typeof(TType)))
        {
            types.Add(typeof(TType));
        }
    }
}
