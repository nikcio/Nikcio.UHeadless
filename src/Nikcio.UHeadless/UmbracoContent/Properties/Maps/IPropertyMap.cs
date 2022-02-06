using Nikcio.UHeadless.UmbracoContent.Properties.Bases.Models;

namespace Nikcio.UHeadless.UmbracoContent.Properties.Maps
{
    public interface IPropertyMap
    {
        void AddAliasMapping<TType>(string contentTypeAlias, string propertyTypeAlias) where TType : PropertyValueBaseGraphType;
        void AddEditorMapping<TType>(string editorName) where TType : PropertyValueBaseGraphType;
        bool ContainsAlias(string contentTypeAlias, string propertyTypeAlias);
        bool ContainsEditor(string editorName);
        string GetAliasValue(string contentTypeAlias, string propertyAlias);
        string GetEditorValue(string key);
    }
}